using IngetMori.Domain.Common.Primitives.Events;

namespace IngetMori.Domain.Common.Primitives;

public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
    where TKey : IEntityKey
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected AggregateRoot(TKey id) : base(id) { }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void ClearDomainEvents() => _domainEvents.Clear();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}