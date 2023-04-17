namespace IngetMori.Domain.Common.Utilities;

public static class Ensure
{
    public static void GreaterThanZero(int value, string message, string argumentName) =>
        Verify(value > 0, message, argumentName);

    public static void GreaterThanOrEqualToZero(int value, string message, string argumentName) =>
        Verify(value >= 0, message, argumentName);

    public static void GreaterThanOrEqualToZero(decimal value, string message, string argumentName) =>
        Verify(value >= decimal.Zero, message, argumentName);

    public static void NotEmpty(string? value, string message, string argumentName) =>
        Verify(!string.IsNullOrEmpty(value), message, argumentName);

    public static void NotEmpty(DateTime value, string message, string argumentName) =>
        Verify(value != default, message, argumentName);

    public static void NotEmpty(Guid value, string message, string argumentName) =>
        Verify(value != Guid.Empty, message, argumentName);

    public static void NotNull(object? value, string message, string argumentName) =>
        Verify(value is not null, message, argumentName);

    private static void Verify(bool result, string message, string argumentName)
    {
        if (!result) { throw new ArgumentException(message, argumentName); }
    }
}
