namespace IngetMori.Domain.Core.ValueObjects;

public record Iban(string Nummer, string? Bic, string TenNameVan)
{
    public string FormattedIban => Nummer.Length != 18
        ? Nummer
        : $"{Nummer[..2]} {Nummer.Substring(startIndex: 2, 2)} {Nummer.Substring(4, 4)} {Nummer.Substring(8, 4)} {Nummer.Substring(12, 4)} {Nummer.Substring(16, 2)}";

}
