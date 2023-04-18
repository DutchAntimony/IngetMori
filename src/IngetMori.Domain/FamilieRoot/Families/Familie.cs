using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.FamilieRoot.Leden;
using IngetMori.Domain.FamilieRoot.Notities;
using System.Diagnostics.CodeAnalysis;

namespace IngetMori.Domain.FamilieRoot.Families;

public class Familie : AggregateRoot<FamilieId>, IAuditableEntity, ISoftDeletableEntity
{
    private readonly List<Lid> _leden = new();
    private readonly List<Notitie> _notities = new();

    private Familie(FamilieId id, Adres adres) : base(id)
    {
        Adres = adres;
        AuditInfo = new();
        DeletionInfo = new();
    }

    public string? AanspreekNaam { get; private set; }
    public Adres Adres { get; private set; }
    public IReadOnlyCollection<Lid>? Leden => _leden;
    public IReadOnlyCollection<Notitie>? Notities => _notities;
    public AuditInfo AuditInfo { get; }
    public DeletionInfo DeletionInfo { get; }


    public static Familie Create(Adres adres, string? aanspreeknaam = null)
    {
        return new(new(Guid.NewGuid()), adres)
        {
            AanspreekNaam = aanspreeknaam
        };
    }


    [NotNullIfNotNull(nameof(Leden))]
    public Lid? HoofdBewoner => Leden?.OrderBy(lid => lid.Lidnummer).FirstOrDefault();

    public string AanspreekNaamDisplay
    {
        get
        {
            if (HoofdBewoner is null)
                return "Geen leden op dit adres";

            if (AanspreekNaam is not null)
                return AanspreekNaam;

            return Leden!.Count == 1 ? HoofdBewoner.VolledigeNaam : HoofdBewoner.NaamAsFamilieNaam;
        }
    }

    public string AdresDisplay => Adres.ToString();

    public bool HasEmail => Leden?.Any(lid => lid.HasPostVervangendEmailAdres) ?? false;

    public override string ToString()
    {
        return AanspreekNaamDisplay;
    }
}


