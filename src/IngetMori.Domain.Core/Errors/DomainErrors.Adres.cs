using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Core.Errors;
public static partial class DomainErrors
{
    public static class Adres
    {
        public static Error StraatMinimumLengte => new
            ($"{nameof(Adres)}.{nameof(StraatMinimumLengte)}",
            "De opgegeven waarde voor de straat voldoet niet aan de minimale lengte.");

        public static Error HuisnummerZero => new
            ($"{nameof(Adres)}.{nameof(HuisnummerZero)}",
            "De opgegeven waarde voor het huisnummer mag niet 0 zijn.");

        public static Error WoonplaatsMinimumLengte => new
            ($"{nameof(Adres)}.{nameof(WoonplaatsMinimumLengte)}",
            "De opgegeven waarde voor de woonplaats voldoet niet aan de minimale lengte.");

        public static Error PostcodeOnjuist => new
            ($"{nameof(Adres)}.{nameof(PostcodeOnjuist)}",
            "De opgegeven waarde voor de postcode voldoet niet aan de eisen voor een postcode.");
    }
}
