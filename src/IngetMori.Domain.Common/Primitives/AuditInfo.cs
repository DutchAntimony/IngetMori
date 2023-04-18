namespace IngetMori.Domain.Common.Primitives;

public sealed class AuditInfo
{
    public string? CreatedBy { get; private set; } = string.Empty;
    public DateTime CreatedOnUtc { get; private set; }

    public string? LastModifiedBy { get; private set; } = string.Empty;
    public DateTime? ModifiedOnUtc { get; private set; }

    public void SetCreated(DateTime created, string? creator = null)
    {
        CreatedBy = creator;
        CreatedOnUtc = created;
    }

    public void SetModified(DateTime modified, string? modifier = null)
    {
        ModifiedOnUtc = modified;
        LastModifiedBy = modifier;
    }
}