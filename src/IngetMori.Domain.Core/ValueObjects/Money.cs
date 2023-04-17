using IngetMori.Domain.Common.Utilities;

namespace IngetMori.Domain.Core.ValueObjects;
public record Money
{
    public decimal Value { get; private set; }
    public string CurrencyCode { get; private set; } = string.Empty;

    public Money(decimal value, string currencyCode)
    {
        Ensure.GreaterThanOrEqualToZero(value, "Money value must be above 0", nameof(value));
        Ensure.NotEmpty(currencyCode, "Currency code must not be empty.", nameof(currencyCode));

        Value = value;
        CurrencyCode = currencyCode;
    }
}
