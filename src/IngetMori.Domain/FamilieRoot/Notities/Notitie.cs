using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.FamilieRoot.Families;
using IngetMori.Domain.FamilieRoot.Leden;

namespace IngetMori.Domain.FamilieRoot.Notities;

public class Notitie : Entity<NotitieId>
{
    private Notitie(NotitieId id, NotitieDiscriminator discriminator) : base(id)
    {
        Discriminator = discriminator;
    }

    public NotitieDiscriminator Discriminator { get; private set; }
    public Guid ForeignKey { get; private set; } = Guid.Empty;
    public string Value { get; private set; } = string.Empty;
    public int Volgnummer { get; private set; }

    public static Notitie CreateNotitieVoorLid(LidId lidId, string value, int volgnummer)
    {
        return new(new NotitieId(Guid.NewGuid()), NotitieDiscriminator.LidNotitie)
        {
            ForeignKey = lidId.Value,
            Value = value,
            Volgnummer = volgnummer
        };
    }

    public static Notitie CreateNotitieVoorFamilie(FamilieId familieId, string value, int volgnummer)
    {
        return new(new NotitieId(Guid.NewGuid()), NotitieDiscriminator.FamilieNotitie)
        {
            ForeignKey = familieId.Value,
            Value = value,
            Volgnummer = volgnummer
        };
    }
}