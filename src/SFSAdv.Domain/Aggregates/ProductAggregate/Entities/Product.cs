using SFSAdv.Domain.Abstractions.Models;

namespace SFSAdv.Domain.Aggregates.ProductAggregate.Entities;

public partial class Product : AggregateRoot
{
    public string Title { get; set; }
    public int InventoryCount { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
}