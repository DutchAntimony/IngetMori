using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Domain.FamilieRoot;

public class Notitie : Entity<NotitieId>
{
    private Notitie(NotitieId id) : base(id) { }

    public NotitieDiscriminator Discriminator { get; private set; }
    public FamilieId FamilieId { get; private set; } = default!;
    public LidId? LidId { get; private set; }
    public string Value { get; private set; } = string.Empty;
    public int Volgnummer { get; private set; }

    public static Notitie CreateNotitieVoorLid(FamilieId familieId, LidId lidId, string value, int volgnummer)
    {
        return new(new NotitieId(Guid.NewGuid()))
        {
            Discriminator = NotitieDiscriminator.LidNotitie,
            FamilieId = familieId,
            LidId = lidId,
            Value = value,
            Volgnummer = volgnummer
        };
    }

    public static Notitie CreateNotitieVoorFamilie(FamilieId familieId, string value, int volgnummer)
    {
        return new(new NotitieId(Guid.NewGuid()))
        {
            Discriminator = NotitieDiscriminator.FamilieNotitie,
            FamilieId = familieId,
            Value = value,
            Volgnummer = volgnummer
        };
    }
}