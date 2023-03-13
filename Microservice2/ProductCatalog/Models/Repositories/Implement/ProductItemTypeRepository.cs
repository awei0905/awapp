using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models.Repositories.Interfaces;

namespace ProductCatalog.Models.Repositories.Implement;

/// <summary>
/// 
/// </summary>
public class ProductItemTypeRepository : IProductItemTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductItemTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<ProductItemType>> GetAllAsync(int productionItemId)
    {
        var productItemTypes = await _dbContext.ProductItemTypes
            .Where(x => x.ProductItemId == productionItemId)
            .ToListAsync();

        return productItemTypes;
    }

    public async Task<int> RemoveRangeAsync(IEnumerable<ProductItemType> entities)
    {
        _dbContext.ProductItemTypes.RemoveRange(entities);
        int saveReturnValue = await _dbContext.SaveChangesAsync();

        return saveReturnValue;
    }

    public async Task<int> AddRangeAsync(IEnumerable<ProductItemType> entities)
    {
        await _dbContext.ProductItemTypes.AddRangeAsync(entities);
        int saveReturnValue = await _dbContext.SaveChangesAsync();

        return saveReturnValue;
    }
}