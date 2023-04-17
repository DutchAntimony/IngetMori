using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Core.ValueObjects;

namespace IngetMori.Domain.Sales;

public class Sale : AggregateRoot<SaleKey>
{
    private Sale(SaleKey id) : base(id) { }

    public string Description { get; private set; } = string.Empty;
    public Money Price { get; private set; } = default!;

    public static Sale Create(string description, Money price)
    {
        return new(new SaleKey(Guid.NewGuid()))
        {
            Description = description,
            Price = price
        };
    }
}
