namespace IngetMori.Domain.Common.Primitives;

public interface IAuditableEntity
{
    DateTime CreatedOnUtc { get; }

    string CreatedBy { get; }

    DateTime? ModifiedOnUtc { get; }

    string ModifiedBy { get; }

    DateTime? DeletedOnUtc { get; }

    string DeletedBy { get; }
}