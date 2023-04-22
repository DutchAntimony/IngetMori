using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Mappers;

internal class EmailAdresMapper
{
    public static EmailAdresResult MapToDto(EmailAdres emailadres) =>
        new(emailadres.Id, emailadres.Value, emailadres.MagPostVervangen);

    internal static IEnumerable<EmailAdresResult> GetFromCollection(IReadOnlyCollection<EmailAdres>? collection)
    {
        return collection?.Select(MapToDto) ?? Enumerable.Empty<EmailAdresResult>();
    }
}
