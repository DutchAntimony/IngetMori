using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Mappers;
internal class NotitieMapper
{
    public static NotitieResult MapToDto(Notitie notitie) =>
        new(notitie.Id, notitie.Value);

    internal static IEnumerable<NotitieResult> GetFromCollection(IReadOnlyCollection<Notitie>? collection)
    {
        return collection?.Select(MapToDto) ?? Enumerable.Empty<NotitieResult>();
    }
}