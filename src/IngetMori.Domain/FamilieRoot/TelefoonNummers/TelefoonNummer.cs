using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.TelefoonNummers;

public class TelefoonNummer : Entity<TelefoonNummerId>
{
    private TelefoonNummer(TelefoonNummerId id) : base(id) { }
    public string Nummer { get; private set; } = string.Empty;
    public string Omschrijving { get; private set; } = string.Empty;
    public int Volgnummer { get; private set; }

    public static TelefoonNummer Create(string nummer, string omschrijving, int volgnummer)
    {
        return new(new TelefoonNummerId(Guid.NewGuid()))
        {
            Nummer = nummer,
            Omschrijving = omschrijving,
            Volgnummer = volgnummer
        };
    }
}
