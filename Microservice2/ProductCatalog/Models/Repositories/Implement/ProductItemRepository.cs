using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models.Repositories.Interfaces;

namespace ProductCatalog.Models.Repositories.Implement;

/// <summary>
/// 
/// </summary>
public class ProductItemRepository : IProductItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dbContext"></param>
    public ProductItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> AddAsync(ProductItem entity)
    {
        await _dbContext.ProductItems.AddAsync(entity);
        int saveChangeReturn = await _dbContext.SaveChangesAsync();

        return saveChangeReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ProductItem>> GetAllAsync()
    {
        var productItems = await _dbContext.ProductItems.OrderBy(x => x.ProductItemId).ToListAsync();

        return productItems;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<ProductItem> GetAsync(Expression<Func<ProductItem, bool>> predicate)
    {
        ProductItem? productItem = await _dbContext.ProductItems.FirstOrDefaultAsync(predicate);

        return productItem;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> RemoveAsync(ProductItem entity)
    {
        _dbContext.Entry(entity).State = EntityState.Deleted;
        int saveChangeReturn = await _dbContext.SaveChangesAsync();

        return saveChangeReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<int> UpdateAsync(ProductItem entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        int saveChangeReturn = await _dbContext.SaveChangesAsync();
        
        return saveChangeReturn;
    }
}