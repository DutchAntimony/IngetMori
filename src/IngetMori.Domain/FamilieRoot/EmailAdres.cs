using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Domain.FamilieRoot;

public class EmailAdres : Entity<EmailAdresId>
{
    private EmailAdres(EmailAdresId id) : base(id) { }

    public LidId LidId { get; private set; }
    public string Value { get; private set; } = string.Empty;
    public bool MagPostVervangen { get; private set; }
    public int Volgnummer { get; private set; }

    public static EmailAdres Create(LidId lidId, string value, bool magPostVervangen, int volgnummer)
    {
        return new(new EmailAdresId(Guid.NewGuid()))
        {
            LidId = lidId,
            Value = value,
            MagPostVervangen = magPostVervangen,
            Volgnummer = volgnummer
        };
    }
}
