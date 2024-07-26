using SFSAdv.Domain.Abstractions.Models;
using SFSAdv.Domain.Aggregates.ProductAggregate;
using SFSAdv.Domain.Aggregates.UserAggregate;

namespace SFSAdv.Domain.Aggregates.OrderAggregate.Entities;

public partial class Order : AggregateRoot
{
    public Product Product { get; private set; }
    public User Buyer { get; private set; }
    public decimal Price { get; private set; }
    public double Discount { get; private set; }
    public DateTime CreationDate { get; private set; }
}

