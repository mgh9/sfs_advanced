using SFSAdv.Domain.Abstractions.Exceptions;
using SFSAdv.Domain.Aggregates.ProductAggregate.Exceptions;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

public partial class Product
{
    public void IncreaseInventory(int amount)
    {
        if (amount < 0)
            throw new DomainValidationException("Amount should be greater than 0.", nameof(amount));

        InventoryCount += amount;
    }

    public void ReduceInventory()
    {
        if (InventoryCount <= 0)
            throw new InsufficientInventoryException($"Insufficient inventory for the product Id `{Id}`");

        InventoryCount--;
    }

    public decimal CalculateFinalPrice()
    {
        return Price - (Price * (decimal)Discount / 100);
    }
}