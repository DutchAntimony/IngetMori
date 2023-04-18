using IngetMori.Domain.Core.Enums;

namespace IngetMori.Domain.Core.ValueObjects;

public record Personalia(string Voornaam, string? Tussenvoegsel, string Achternaam, Geslacht Geslacht, DateOnly Geboortedatum)
{
    private string FormattedTussenvoegsel => string.IsNullOrWhiteSpace(Tussenvoegsel) ? "" : $"{Tussenvoegsel} ";
    public override string ToString() =>
        $"{Geslacht.DisplayName()} {Voornaam} {Tussenvoegsel}{Achternaam}";

    public string NaamAsFamilieNaam => $"Fam. {FormattedTussenvoegsel}{Achternaam}";
    public int GetAge(DateOnly? compareTo = null)
    {
        var compare = compareTo ?? DateOnly.FromDateTime(DateTime.Now);

        int age = compare.Year - Geboortedatum.Year;
        if (compare.Month < Geboortedatum.Month || (compare.Month == Geboortedatum.Month && compare.Day < Geboortedatum.Day))
        {
            age--;
        }

        return age;
    }
}
