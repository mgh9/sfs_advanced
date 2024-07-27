using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Utilities;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

public partial class Product
{
    private Product()
    {
    }

    public static Product Create(Guid id, string title, int inventoryCount, decimal price, double discount)
    {
        Guard.AgainstEmpty(id, nameof(id));
        Guard.AgainstNullOrEmpty(title, nameof(title));
        Guard.AgainstNegative(inventoryCount, nameof(inventoryCount));
        Guard.AgainstNegative(price, nameof(price));
        Guard.AgainstNegative((double)discount, nameof(discount));
        if(title.Length> 40)
        {
            throw new DomainValidationException("Product title must be less than 40 characters");
        }

        return new Product
        {
            Id = id,
            Title = title,
            InventoryCount = inventoryCount,
            Price = price,
            Discount = discount
        };
    }

    public static Product CreateWithDefaults(string title, int inventoryCount, decimal price, double discount)
    {
        return Create(Guid.NewGuid(), title, inventoryCount, price, discount);
    }
}
