using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.Families;

public record struct FamilieId(Guid Value) : IEntityKey;
