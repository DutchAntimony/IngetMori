using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Domain.Common.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IngetMori.Persistence;
public sealed class IngetMoriDbContext : DbContext, IDbContext
{
    private readonly IPublisher _publisher;
    private readonly IDateTimeProvider _dateTime;

    public IngetMoriDbContext(DbContextOptions options, IDateTimeProvider dateTime, IPublisher publisher) : base(options)
    {
        _dateTime = dateTime;
        _publisher = publisher;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity, TKey>()
    where TEntity : Entity<TKey>
    where TKey : IEntityKey =>
        await base.Set<TEntity>().ToListAsync();

    /// <inheritdoc />
    public IQueryable<TEntity> GetAllAsQueryable<TEntity, TKey>()
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        base.Set<TEntity>();

    /// <inheritdoc />
    public async Task<TEntity?> GetBydIdAsync<TEntity, TKey>(TKey id)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        await Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Value == id.Value);

    /// <inheritdoc />
    public void Insert<TEntity, TKey>(TEntity entity)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        Set<TEntity>().Add(entity);

    /// <inheritdoc />
    public void Remove<TEntity, TKey>(TEntity entity)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        Set<TEntity>().Remove(entity);


    /// <summary>
    /// Saves all of the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of entities that have been saved.</returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();

        await PublishDomainEvents(cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngetMoriDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    private void UpdateAuditableEntities()
    {
        foreach (EntityEntry<IAuditableEntity> entityEntry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(nameof(IAuditableEntity.CreatedOnUtc)).CurrentValue = _dateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(nameof(IAuditableEntity.ModifiedOnUtc)).CurrentValue = _dateTime.UtcNow;
            }
        }
    }

    /// <summary>
    /// Publishes and then clears all the domain events that exist within the current transaction.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    private async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        var entities = ChangeTracker
            .Entries<IAggregateRoot>()
            .Where(entityEntry => entityEntry.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = entities.SelectMany(entityEntry => entityEntry.Entity.DomainEvents).ToList();

        entities.ForEach(entityEntry => entityEntry.Entity.ClearDomainEvents());

        IEnumerable<Task> tasks = domainEvents.Select(domainEvent => _publisher.Publish(domainEvent, cancellationToken));

        await Task.WhenAll(tasks);
    }
}
