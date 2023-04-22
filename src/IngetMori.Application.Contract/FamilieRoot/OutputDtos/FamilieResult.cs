using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

// LET OP: Als hier properties aan toe worden gevoegd moeten deze ook gemapt worden in het FamilieDetailResult!
public record FamilieResult()
{
    public FamilieId Id { get; init; }
    public required string Aanspreeknaam { get; init; }
    public required string Adres { get; init; }
    public bool HasIncassoLeden { get; init; }
    public bool HasNotaLeden { get; init; }
    public bool HasGratisLeden { get; init; }
    public bool HasPostVervangendeEmail { get; init; }
}
