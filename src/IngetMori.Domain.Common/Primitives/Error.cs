namespace IngetMori.Domain.Common.Primitives;

/// <summary>
/// An error used in the result class if the result is a failure
/// </summary>
/// <param name="Code"></param>
/// <param name="Message"></param>
public sealed record Error(string Code, string Message)
{
    /// <summary>
    /// There is no error.
    /// </summary>
    internal static Error None => new(string.Empty, string.Empty);

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;
}
