using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.Enums;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.FamilieRoot.Leden;

namespace IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;

public class IncassoMandaad : AggregateRoot<IncassoMandaadId>
{
    private readonly List<Lid> _leden = new();

    private IncassoMandaad(IncassoMandaadId id, Iban iban) : base(id)
    {
        Iban = iban;
    }

    public Iban Iban { get; private set; }
    public MandaadType? MandaadType { get; private set; }
    public DateOnly? MandaadDatum { get; private set; }

    public IReadOnlyCollection<Lid> Leden => _leden;

    public static IncassoMandaad Create(Iban iban, MandaadType? mandaadType, DateOnly? mandaadDatum)
    {
        return new(new IncassoMandaadId(Guid.NewGuid()), iban)
        {
            MandaadType = mandaadType,
            MandaadDatum = mandaadDatum
        };
    }

    public override string ToString() => $"{Iban?.FormattedIban}\nTnv: {Iban?.TenNameVan}";
}
