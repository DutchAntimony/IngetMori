namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

public record FamilieDetailResult() : FamilieResult
{
    public static FamilieDetailResult FromBase(FamilieResult baseResult)
    {
        return new()
        {
            Id = baseResult.Id,
            Aanspreeknaam = baseResult.Aanspreeknaam,
            Adres = baseResult.Adres,
            HasIncassoLeden = baseResult.HasIncassoLeden,
            HasNotaLeden = baseResult.HasNotaLeden,
            HasGratisLeden = baseResult.HasGratisLeden,
            HasPostVervangendeEmail = baseResult.HasPostVervangendeEmail
        };
    }

    public IEnumerable<LidResult>? Leden { get; init; }
    public IEnumerable<NotitieResult>? Notities { get; init; }
}
