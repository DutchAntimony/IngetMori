using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.Core.Enums;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Mappers;

internal class FamilieMapper
{
    public static FamilieResult MapToDto(Familie familie)
    {
        return new()
        {
            Id = familie.Id,
            Aanspreeknaam = familie.AanspreekNaamDisplay,
            Adres = familie.AdresDisplay,
            HasIncassoLeden = familie.Leden?.Any(l => l.Betaalwijze == Betaalwijze.Inc) ?? false,
            HasNotaLeden = familie.Leden?.Any(l => l.Betaalwijze == Betaalwijze.Nota) ?? false,
            HasGratisLeden = familie.Leden?.Any(l => l.Betaalwijze == Betaalwijze.Nvt) ?? false,
            HasPostVervangendeEmail = familie.HasEmail
        };
    }

    public static FamilieDetailResult MapToDetailDto(Familie familie)
    {
        return FamilieDetailResult.FromBase(MapToDto(familie)) with
        {
            Leden = LidMapper.GetFromCollection(familie.Leden),
            Notities = NotitieMapper.GetFromCollection(familie.Notities)
        };
    }
}