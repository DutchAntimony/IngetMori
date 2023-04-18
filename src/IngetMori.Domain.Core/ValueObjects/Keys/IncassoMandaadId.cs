using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;

public record struct IncassoMandaadId(Guid Value) : IEntityKey;
