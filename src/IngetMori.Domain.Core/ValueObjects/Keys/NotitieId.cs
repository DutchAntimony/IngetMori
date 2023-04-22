using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Core.ValueObjects.Keys;

public record struct NotitieId(Guid Value) : IEntityKey;
