using System.ComponentModel.DataAnnotations;

namespace IngetMori.Domain.Core.Enums;
public enum Betaalwijze
{
    [Display(Name = "Incasso")]
    Inc,
    [Display(Name = "Nota")]
    Nota,
    [Display(Name = "Geen")]
    Nvt
}
