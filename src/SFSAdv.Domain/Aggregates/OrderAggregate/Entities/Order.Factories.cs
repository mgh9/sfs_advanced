using SFSAdv.Domain.Aggregates.OrderAggregate.Events;
using SFSAdv.Domain.Aggregates.ProductAggregate.Entities;
using SFSAdv.Domain.Aggregates.UserAggregate.Entities;
using SFSAdv.Domain.Utilities;

namespace SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

public partial class Order
{
    private Order()
    {
    }

    public static Order Create(Guid id, Product product, User buyer)
    {
        Guard.AgainstEmpty(id, nameof(id));
        Guard.AgainstNull(product, nameof(product));
        Guard.AgainstNull(buyer, nameof(buyer));

        var order = new Order
        {
            Id = id,
            Product= product,
            Buyer = buyer,
            Price = product.Price,
            Discount = product.Discount,
            CreationDate = DateTime.Now,
        };

        order.AddDomainEvent(new OrderCreatedEvent(id, product.Id, buyer.Id,product.Price, product.Discount, order.CreationDate));

        return order;
    }
}
