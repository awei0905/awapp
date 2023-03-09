namespace ProductCatalog.Models.DTOs;

public class ProductGetAllDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public IEnumerable<string> ProductType { get; set; }
}