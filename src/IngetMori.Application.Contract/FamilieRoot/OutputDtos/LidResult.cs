using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

// LET OP: Als hier properties aan toe worden gevoegd moeten deze ook gemapt worden in het LidDetailResult!
public record LidResult
{
    public required LidId Id { get; init; }
    public required int Lidnummer { get; init; }
    public required string VolledigeNaam { get; init; }
    public required string LeeftijdInfo { get; init; }
    public bool HasPhone { get; init; }
    public bool HasEmail { get; init; }
    public bool HasNotes { get; init; }
}
