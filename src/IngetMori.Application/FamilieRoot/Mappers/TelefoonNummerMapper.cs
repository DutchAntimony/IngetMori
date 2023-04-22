using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Mappers;

internal class TelefoonNummerMapper
{
    public static TelefoonNummerResult MapToDto(TelefoonNummer telefoonNummer) =>
        new(telefoonNummer.Id, telefoonNummer.Nummer, telefoonNummer.Omschrijving);

    public static IEnumerable<TelefoonNummerResult> GetFromCollection(IReadOnlyCollection<TelefoonNummer>? collection)
    {
        return collection?.Select(MapToDto) ?? Enumerable.Empty<TelefoonNummerResult>();
    }
}
