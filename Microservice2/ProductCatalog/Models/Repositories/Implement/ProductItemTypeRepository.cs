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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbContext"></param>
    public ProductItemTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> AddAsync(ProductItemType entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ProductItemType>> GetAllAsync(int productionItemId)
    {
        var productItemTypes = await _dbContext.ProductItemTypes
            .Where(x => x.ProductItemId == productionItemId)
            .ToListAsync();

        return productItemTypes;
    }

    public async Task<int> RemoveAsync(ProductItemType entity)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(ProductItemType entity)
    {
        throw new NotImplementedException();
    }
}