using SFSAdv.Domain.Abstractions.Exceptions;

namespace SFSAdv.Domain.Aggregates.ProductAggregate;

public partial class Product
{
    public void IncreaseInventory(int amount)
    {
        if (amount < 0)
            throw new InvalidInputDataException("Amount should be greater than 0.", nameof(amount));

        InventoryCount += amount;
    }


    public void ApplyDiscount(double discount)
    {
        if (discount < 0)
            throw new InvalidInputDataException("Discount should be greater than or equal to 0.", nameof(discount));

        Discount = discount;
    }
}