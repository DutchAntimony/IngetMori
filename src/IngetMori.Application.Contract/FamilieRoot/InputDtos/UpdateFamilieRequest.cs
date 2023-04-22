namespace IngetMori.Application.Contract.FamilieRoot.InputDtos;

public record UpdateFamilieRequest(string? AanspreekNaam, string Straat, int Huisnummer, string? Toevoegsel, string Postcode, string Woonplaats, string? Land);
