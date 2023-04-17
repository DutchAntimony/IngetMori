namespace IngetMori.Application.Common.Abstractions.Services;

public class IDateTimeProvider
{
    public DateTime UtcNow { get; }
    public DateTime Now { get; }
    public DateOnly Today { get; }
}
