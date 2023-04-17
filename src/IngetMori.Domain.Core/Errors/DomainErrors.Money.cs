using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Core.Errors;
public static partial class DomainErrors
{
    public static class Money
    {
        public static Error ValueNotNegative => 
            new($"{nameof(Money)}.{nameof(ValueNotNegative)}", "Money value must not be negative");
        
        public static Error CurrencyCodeNotEmpty =>
            new($"{nameof(Money)}.{nameof(CurrencyCodeNotEmpty)}", "Currency code must not be empty");
    }
}
