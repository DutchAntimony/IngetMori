using IngetMori.Domain.Common.Utilities;

namespace IngetMori.Domain.Common.Primitives;

public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
    where TKey : IEntityKey
{
    protected Entity(TKey id)
    {
        Ensure.NotEmpty(id.Value, "The entity identifier must not be empty.", nameof(id));

        Id = id;
    }

    [Obsolete("Do not use, only for EF Core")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public TKey Id { get; private set; }

    public static bool operator ==(Entity<TKey> a, Entity<TKey> b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TKey> a, Entity<TKey> b) => !(a == b);

    public bool Equals(Entity<TKey>? other)
    {
        if (other is null)
        {
            return false;
        }

        return ReferenceEquals(this, other) || Id.Value.Equals(other.Id.Value);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Entity<TKey> other)
        {
            return false;
        }

        return Id.Value.Equals(other.Id.Value);
    }

    public override int GetHashCode() => Id.Value.GetHashCode() * 29;
}
