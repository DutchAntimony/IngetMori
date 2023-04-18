using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.Enums;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;

namespace IngetMori.Domain.FamilieRoot;

public class Lid : Entity<LidId>, IAuditableEntity, ISoftDeletableEntity
{
    private readonly List<TelefoonNummer> _telefoonNummers = new();
    private readonly List<EmailAdres> _emailAdressen = new();
    private readonly List<Notitie> _notities = new();

    private Lid(LidId id) : base(id)
    {
        AuditInfo = new();
        DeletionInfo = new();
    }

    public int Lidnummer { get; private set; }
    public Personalia Personalia { get; private set; } = default!;
    public virtual FamilieId FamilieId { get; private set; } = default!;
    public IReadOnlyCollection<TelefoonNummer>? Telefoonnummers => _telefoonNummers;
    public IReadOnlyCollection<EmailAdres>? EmailAdressen => _emailAdressen;
    public Betaalwijze Betaalwijze { get; private set; } = default!;
    public IncassoMandaadId? IncassoMandaadId { get; private set; }
    public Uitschrijfreden? Uitschrijfreden { get; private set; }
    public IReadOnlyCollection<Notitie>? Notities => _notities;
    public AuditInfo AuditInfo { get; }
    public DeletionInfo DeletionInfo { get; }

    public static Lid Create(int lidnummer, Personalia personalia, Familie familie, Betaalwijze betaalwijze, IncassoMandaadId? incassoMandaadId, Uitschrijfreden? uitschrijfreden)
    {
        return new(new LidId(Guid.NewGuid()))
        {
            Lidnummer = lidnummer,
            Personalia = personalia,
            FamilieId = familie.Id,
            Betaalwijze = betaalwijze,
            IncassoMandaadId = incassoMandaadId,
            Uitschrijfreden = uitschrijfreden
        };
    }

    public string VolledigeNaam => Personalia.ToString();
    public string NaamAsFamilieNaam => Personalia.NaamAsFamilieNaam;
    public bool HasPostVervangendEmailAdres => EmailAdressen?.Any(email => email.MagPostVervangen) ?? false;

    public override string ToString()
    {
        return VolledigeNaam;
    }
}
