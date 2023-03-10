using ProductCatalog.Data;

namespace ProductCatalog.Seeders;

public class DataSeeder {
    private readonly ApplicationDbContext _dbContext;

    public DataSeeder(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }

    public void SeedProductsAndProductCatalogTypes() {
        if(!_dbContext.ProductItems.Any()) {
            var productTypes = new List<ProductType> {
                new ProductType {
                    ProductTypeId = 1,
                    Name = "平民美食",
                },
                new ProductType {
                    ProductTypeId = 2,
                    Name = "養身",
                },
            };
            var productItems = new List<ProductItem> {
                new ProductItem {
                    Name = "貴格超大便當",
                    Description = "要不要注意膽固醇。",
                    ImageUrl = "https://i.imgur.com/r4lq4Ad.jpg",
                    Price = 100,                  
                },
                new ProductItem {
                    Name = "貴格超大燕麥",
                    Description = "要不要注意體脂肪。",
                    ImageUrl = "https://i.imgur.com/r4lq4Ad.jpg",
                    Price = 150,                 
                },
            };
            var productItemTypes = new List<ProductItemType> { 
                new ProductItemType {
                    ProductItemId = 1,
                    ProductTypeId = 1,
                },
                new ProductItemType {
                    ProductItemId = 1,
                    ProductTypeId = 2,
                },
                new ProductItemType {
                    ProductItemId = 2,
                    ProductTypeId = 2,
                },
            };

            _dbContext.ProductTypes.AddRange(productTypes);
            _dbContext.ProductItems.AddRange(productItems);
            _dbContext.ProductItemTypes.AddRange(productItemTypes);
            _dbContext.SaveChanges();
        }
    }
}