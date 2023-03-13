using ProductCatalog.Data;

namespace ProductCatalog.Seeders;

public class DataSeeder {
    private readonly ApplicationDbContext _dbContext;

    public DataSeeder(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void SeedProductsAndProductCatalogTypes() {
        if(!_dbContext.ProductItems.Any()) {
            var productItems = new List<ProductItem> {
                new ProductItem {
                    Name = "貴格超大便當",
                    Description = "要不要注意膽固醇。",
                    ImageUrl = "https://i.imgur.com/r4lq4Ad.jpg",
                    Price = 100,
                    Quantity = 20,
                },
                new ProductItem {
                    Name = "貴格超大燕麥",
                    Description = "要不要注意體脂肪。",
                    ImageUrl = "https://i.imgur.com/r4lq4Ad.jpg",
                    Price = 150,  
                    Quantity = 15,               
                },
            };
            _dbContext.ProductItems.AddRange(productItems);
            _dbContext.SaveChanges();
        }
    }
}