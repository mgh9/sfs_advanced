using SFSAdv.Domain.Abstractions.Models;

namespace SFSAdv.Domain.Aggregates.ProductAggregate;

public partial class Product : AggregateRoot
{
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
}