using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.FamilieRoot;
using IngetMori.Persistence.Extensions;
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

    public DbSet<Familie> Families => Set<Familie>();

    [Obsolete]
    /// <inheritdoc />
    public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity, TKey>()
    where TEntity : Entity<TKey>
    where TKey : IEntityKey =>
        await base.Set<TEntity>().ToListAsync();

    [Obsolete]
    /// <inheritdoc />
    public IQueryable<TEntity> GetAllAsQueryable<TEntity, TKey>()
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        base.Set<TEntity>();

    [Obsolete]
    /// <inheritdoc />
    public async Task<TEntity?> GetBydIdAsync<TEntity, TKey>(TKey id)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey =>
        await Set<TEntity>().FirstOrDefaultAsync(e => e.Id.Value == id.Value);

    [Obsolete]
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


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities(null);

        await PublishDomainEvents(cancellationToken);

        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngetMoriDbContext).Assembly);

        modelBuilder.ApplyUtcDateTimeConverter();

        base.OnModelCreating(modelBuilder);
    }

    private void UpdateAuditableEntities(string? user)
    {
        foreach (EntityEntry<ISoftDeletableEntity> entityEntry in ChangeTracker.Entries<ISoftDeletableEntity>())
        {
            if (entityEntry.State == EntityState.Deleted)
            {
                entityEntry.Entity.DeletionInfo.SetAsDeleted(_dateTime.UtcNow, user);
                entityEntry.State = EntityState.Modified;
            }
        }

        foreach (EntityEntry<IAuditableEntity> entityEntry in ChangeTracker.Entries<IAuditableEntity>())
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.AuditInfo.SetCreated(_dateTime.UtcNow, user);
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.AuditInfo.SetModified(_dateTime.UtcNow, user);
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
