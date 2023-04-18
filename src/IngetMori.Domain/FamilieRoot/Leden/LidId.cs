using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.Leden;

public record struct LidId(Guid Value) : IEntityKey;
