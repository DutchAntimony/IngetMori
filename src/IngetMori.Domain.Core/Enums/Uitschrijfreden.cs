using System.ComponentModel.DataAnnotations;

namespace IngetMori.Domain.Core.Enums;
public enum Uitschrijfreden
{
    [Display(Name = "Overleden")]
    Overleden,
    [Display(Name = "Geen betalend lid")]
    GeenBetalendLid,
    [Display(Name = "Opzegging")]
    Opzegging,
    [Display(Name = "Overschrijving")]
    Overschrijving
}
