using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.Sales;

namespace IngetMori.Application.Contract.Sale;

public record SaleResult(SaleKey Id, string Title, Money Price);