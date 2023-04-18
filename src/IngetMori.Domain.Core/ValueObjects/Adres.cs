namespace IngetMori.Domain.Core.ValueObjects;

public record Adres(string Straat, int Huisnummer, string? Toevoegsel, string Postcode, string Woonplaats, string? Land)
{
    private string LandDisplay => Land == "NL" || Land is null ? "" : $"({Land})";
    public override string ToString()
    {
        return $"{Straat} {Huisnummer} {Toevoegsel}\n{Postcode} {Woonplaats?.ToUpper()}{LandDisplay}";
    }
}