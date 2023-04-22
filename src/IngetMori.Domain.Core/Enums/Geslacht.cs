using System.ComponentModel.DataAnnotations;

namespace IngetMori.Domain.Core.Enums;
public enum Geslacht
{
    [Display(Name = "Dhr.")]
    M,
    [Display(Name = "Mevr.")]
    V
}
