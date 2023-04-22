using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.Enums;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.FamilieRoot;
using IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;

namespace IngetMori.Domain.IncassoMandaadRoot;

public class IncassoMandaad : AggregateRoot<IncassoMandaadId>
{
    private readonly List<Lid> _leden = new();

    private IncassoMandaad(IncassoMandaadId id) : base(id) { }

    public Iban Iban { get; private set; } = default!;
    public MandaadType? MandaadType { get; private set; }
    public DateOnly? MandaadDatum { get; private set; }

    public IReadOnlyCollection<Lid> Leden => _leden;

    public static IncassoMandaad Create(Iban iban, MandaadType? mandaadType, DateOnly? mandaadDatum)
    {
        return new(new IncassoMandaadId(Guid.NewGuid()))
        {
            Iban = iban,
            MandaadType = mandaadType,
            MandaadDatum = mandaadDatum
        };
    }

    public override string ToString() => $"{Iban?.FormattedIban}\nTnv: {Iban?.TenNameVan}";
}
