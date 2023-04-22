using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Core.ValueObjects.Keys;

public record struct LidId(Guid Value) : IEntityKey;
