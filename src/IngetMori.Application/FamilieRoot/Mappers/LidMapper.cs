using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Mappers;

internal class LidMapper
{
    public static LidResult MapToDto(Lid lid)
    {
        return new()
        {
            Id = lid.Id,
            Lidnummer = lid.Lidnummer,
            VolledigeNaam = lid.VolledigeNaam,
            LeeftijdInfo = $"{lid.Personalia.Geboortedatum} ({lid.Personalia.GetAge()})",
            HasEmail = lid.EmailAdressen?.Any() ?? false,
            HasPhone = lid.Telefoonnummers?.Any() ?? false,
            HasNotes = lid.Notities?.Any() ?? false
        };
    }

    public static LidDetailResult MapToResultDto(Lid lid)
    {
        return LidDetailResult.FromBase(MapToDto(lid)) with
        {
            Betaalwijze = lid.Betaalwijze,
            TelefoonNummers = TelefoonNummerMapper.GetFromCollection(lid.Telefoonnummers),
            EmailAdressen = EmailAdresMapper.GetFromCollection(lid.EmailAdressen),
            IbanDetails = "Deze functionaliteit is nog niet geimplementeerd",
            Uitschrijfreden = lid.Uitschrijfreden,
            Notities = NotitieMapper.GetFromCollection(lid.Notities)
        };
    }

    internal static IEnumerable<LidResult> GetFromCollection(IReadOnlyCollection<Lid>? collection)
    {
        return collection?.Select(MapToDto) ?? Enumerable.Empty<LidResult>();
    }
}
