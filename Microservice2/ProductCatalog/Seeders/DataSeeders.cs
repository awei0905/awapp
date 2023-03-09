using ProductCatalog.Data;

namespace ProductCatalog.Seeders;

public class DataSeeder {
    private readonly ApplicationDbContext _dbContext;

    public DataSeeder(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void SeedProductsAndProductCatalogTypes() {
        if(!_dbContext.ProductItems.Any()) {
            var productsCatalogTypes = new List<ProductType> {
                new ProductType {
                    Name = "養身產品",
                },
            };
            var products = new List<ProductItem> {
                new ProductItem {
                    Name = "貴格超大便當",
                    Description = "要不要注意膽固醇。",
                    // = "https://example.com",
                    Price = 100,
                    ProductCatalogTypeId = 1,                    
                },
            };
            _dbContext.ProductTypes.AddRange(productsCatalogTypes);
            _dbContext.ProductItems.AddRange(products);
            _dbContext.SaveChanges();
        }
    }
}