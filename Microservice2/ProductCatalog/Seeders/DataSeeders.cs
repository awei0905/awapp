using ProductCatalog.Data;

namespace ProductCatalog.Seeders;

public class DataSeeder {
    private readonly ApplicationDbContext _dbContext;

    public DataSeeder(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void SeedProductsAndProductCatalogTypes() {
        if(!_dbContext.ProductItems.Any()) {
            var productsCatalogTypes = new List<ProductCatalogType> {
                new ProductCatalogType {
                    Name = "養身產品",
                    Subname = "貴格",
                },
            };
            var products = new List<ProductItem> {
                new ProductItem {
                    Name = "貴格超大便當",
                    Description = "要不要注意膽固醇。",
                    PictureFileName = "https://example.com",
                    Price = 100,
                    ProductCatalogTypeId = 1,                    
                },
            };
            _dbContext.ProductCatalogTypes.AddRange(productsCatalogTypes);
            _dbContext.ProductItems.AddRange(products);
            _dbContext.SaveChanges();
        }
    }
}