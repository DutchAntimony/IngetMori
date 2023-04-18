using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.EmailAdressen;

public class EmailAdres : Entity<EmailAdresId>
{
    private EmailAdres(EmailAdresId id) : base(id) { }

    public string Value { get; private set; } = string.Empty;
    public bool MagPostVervangen { get; private set; }
    public int Volgnummer { get; private set; }

    public static EmailAdres Create(string value, bool magPostVervangen, int volgnummer)
    {
        return new(new EmailAdresId(Guid.NewGuid()))
        {
            Value = value,
            MagPostVervangen = magPostVervangen,
            Volgnummer = volgnummer
        };
    }
}
