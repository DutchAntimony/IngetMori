using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.FamilieRoot.Notities;

public record struct NotitieId(Guid Value) : IEntityKey;
