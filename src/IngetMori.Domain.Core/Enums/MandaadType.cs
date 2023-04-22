using System.ComponentModel.DataAnnotations;

namespace IngetMori.Domain.Core.Enums;
public enum MandaadType
{
    [Display(Name = "Groene kaart")]
    GroeneKaart,
    [Display(Name = "Sepa machtiging")]
    SepaMachtiging,
    [Display(Name = "Email bevestiging")]
    Email
}
