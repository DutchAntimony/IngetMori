using IngetMori.Domain.Common.Primitives.Events;

namespace IngetMori.Domain.Common.Primitives;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}