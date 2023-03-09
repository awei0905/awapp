namespace ProductCatalog.Models.Params;

public class ProductCreateParam
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = null!;
    public IEnumerable<string> Types { get; set; } = null!;
}