using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Domain.FamilieRoot;

public class TelefoonNummer : Entity<TelefoonNummerId>
{
    private TelefoonNummer(TelefoonNummerId id) : base(id) { }
    
    public LidId LidId { get; private set; }
    public string Nummer { get; private set; } = string.Empty;
    public string Omschrijving { get; private set; } = string.Empty;
    public int Volgnummer { get; private set; }

    public static TelefoonNummer Create(LidId lidId, string nummer, string omschrijving, int volgnummer)
    {
        return new(new TelefoonNummerId(Guid.NewGuid()))
        {
            LidId = lidId,
            Nummer = nummer,
            Omschrijving = omschrijving,
            Volgnummer = volgnummer
        };
    }
}
