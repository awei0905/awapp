namespace ProductCatalog.Models.DTOs;

public class ProductGetDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public IEnumerable<string> ProductType { get; set; } = null!;
}