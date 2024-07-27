namespace SFSAdv.Domain.Aggregates.ProductAggregate.ReadModels;

public class ProductReadModel
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public int InventoryCount { get; set; }
    
    public decimal Price { get; set; }
    public double Discount { get; set; }
    public decimal FinalPrice { get; set; }
}
