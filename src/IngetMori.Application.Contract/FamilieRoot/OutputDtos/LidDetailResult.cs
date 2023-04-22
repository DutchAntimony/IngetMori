using IngetMori.Domain.Core.Enums;

namespace IngetMori.Application.Contract.FamilieRoot.OutputDtos;

public record LidDetailResult() : LidResult
{
    public static LidDetailResult FromBase(LidResult baseResult)
    {
        return new()
        {
            Id = baseResult.Id,
            Lidnummer = baseResult.Lidnummer,
            VolledigeNaam = baseResult.VolledigeNaam,
            LeeftijdInfo = baseResult.LeeftijdInfo,
            HasEmail = baseResult.HasEmail,
            HasPhone = baseResult.HasPhone,
            HasNotes = baseResult.HasNotes
        };
    }
    public Betaalwijze Betaalwijze { get; init; }
    public IEnumerable<TelefoonNummerResult> TelefoonNummers { get; init; } = Enumerable.Empty<TelefoonNummerResult>();
    public IEnumerable<EmailAdresResult> EmailAdressen { get; init; } = Enumerable.Empty<EmailAdresResult>();
    public string? IbanDetails { get; init; }
    public Uitschrijfreden? Uitschrijfreden { get; init; }
    public IEnumerable<NotitieResult> Notities { get; init; } = Enumerable.Empty<NotitieResult>();
}
