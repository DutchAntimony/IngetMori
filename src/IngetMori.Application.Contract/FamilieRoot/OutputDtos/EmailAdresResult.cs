using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

public record EmailAdresResult(EmailAdresId Id, string EmailAdres, bool MagPostVervangen);
