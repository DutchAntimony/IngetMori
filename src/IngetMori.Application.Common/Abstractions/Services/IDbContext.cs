using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;

namespace IngetMori.Application.Common.Abstractions.Services;

/// <summary>
/// Represents the database context interface.
/// </summary>
public interface IDbContext
{
    DbSet<Familie> Families { get; }

    /// <summary>
    /// Gets all entries for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <returns>The database set for the specified entity type.</returns>
    [Obsolete("Use concrete repositories rather then generic arguments")]
    Task<IEnumerable<TEntity>> GetAllAsync<TEntity, TKey>()
        where TEntity : Entity<TKey>
        where TKey : IEntityKey;

    /// <summary>
    /// Gets the database set as an IQueryable for the specified entity type.
    /// </summary>
    /// <typeparam name="TEntity">the entity type.</typeparam>
    /// <typeparam name="TKey">the key of the entity type.</typeparam>
    /// <returns>The IQueryable of the specified entity type.</returns>
    [Obsolete("Use concrete repositories rather then generic arguments")]
    IQueryable<TEntity> GetAllAsQueryable<TEntity, TKey>()
        where TEntity : Entity<TKey>
        where TKey : IEntityKey;

    /// <summary>
    /// Gets the entity with the specified identifier.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">the key of the entity type.</typeparam>
    /// <param name="id">The entity identifier.</param>
    /// <returns>The instance with the specified identifier, or null if no such entity exists.</returns>
    [Obsolete("Use concrete repositories rather then generic arguments")]
    Task<TEntity?> GetBydIdAsync<TEntity, TKey>(TKey id)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey;

    /// <summary>
    /// Inserts the specified entity into the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">the key of the entity type.</typeparam>
    /// <param name="entity">The entity to be inserted into the database.</param>
    [Obsolete("Use concrete repositories rather then generic arguments")]
    void Insert<TEntity, TKey>(TEntity entity)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey;

    /// <summary>
    /// Removes the specified entity from the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TKey">the key of the entity type.</typeparam>
    /// <param name="entity">The entity to be removed from the database.</param>
    [Obsolete("Use concrete repositories rather then generic arguments")]
    void Remove<TEntity, TKey>(TEntity entity)
        where TEntity : Entity<TKey>
        where TKey : IEntityKey;

    /// <summary>
    /// Saves all of the pending changes in the unit of work.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The number of entities that have been saved.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
