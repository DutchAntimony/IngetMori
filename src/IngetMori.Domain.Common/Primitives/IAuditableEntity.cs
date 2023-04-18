namespace IngetMori.Domain.Common.Primitives;

public interface IAuditableEntity
{
    AuditInfo AuditInfo { get; }
}