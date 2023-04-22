using FluentValidation;
using IngetMori.Domain.Common.Extensions;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.Core.Errors;

namespace IngetMori.Domain.Core.ValueObjectValidators;
public class AdresValidator : AbstractValidator<Adres>
{
    private const string dutchPostcodeRegex = "[1-9][0-9]{3}\\s*(?:[a-zA-Z]{2})?";
    public AdresValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(a => a).NotNull();
        RuleFor(a => a.Straat).MinimumLength(2).WithError(DomainErrors.Adres.StraatMinimumLengte);
        RuleFor(a => a.Huisnummer).NotEmpty().WithError(DomainErrors.Adres.HuisnummerZero);
        RuleFor(a => a.Postcode)
            .MinimumLength(2)
            .MaximumLength(8)
            .WithError(DomainErrors.Adres.PostcodeOnjuist);
        RuleFor(a => a.Postcode).Matches(dutchPostcodeRegex)
            .When(a => a.Land is null || a.Land.ToLower() == "nl")
            .WithError(DomainErrors.Adres.PostcodeOnjuist);
        RuleFor(a => a.Woonplaats).MinimumLength(2).WithError(DomainErrors.Adres.WoonplaatsMinimumLengte);

    }
}
