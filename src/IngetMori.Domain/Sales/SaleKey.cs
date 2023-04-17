using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Sales;

public record struct SaleKey(Guid Value) : IEntityKey;
