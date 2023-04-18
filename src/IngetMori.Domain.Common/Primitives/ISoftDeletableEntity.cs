namespace IngetMori.Domain.Common.Primitives;

public interface ISoftDeletableEntity
{
    public DeletionInfo DeletionInfo { get; }
}

public class DeletionInfo
{
    public bool IsDeleted { get; private set; } = false;
    public DateTime? DeletedOnUtc { get; private set; }
    public string? DeletedBy { get; private set; }

    public void SetAsDeleted(DateTime deletedOnUtc, string? deletedBy)
    {
        IsDeleted = true;
        DeletedOnUtc = deletedOnUtc;
        DeletedBy = deletedBy;
    }
}