namespace IngetMori.Application.Contract.FamilieRoot.InputDtos;
public record CreateFamilieRequest(string Straat, int Huisnummer, string? Toevoegsel, string Postcode, string Woonplaats, string? Land);
