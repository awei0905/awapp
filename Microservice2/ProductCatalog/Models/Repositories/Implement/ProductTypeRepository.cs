using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models.Repositories.Interfaces;

namespace ProductCatalog.Models.Repositories.Implement;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductTypeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> AddAsync(ProductType entity)
    {
        await _dbContext.ProductTypes.AddAsync(entity);
        int saveChangeReturn = await _dbContext.SaveChangesAsync();

        return saveChangeReturn;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<ProductType>> GetAllAsync(Expression<Func<ProductType, bool>> predicate)
    {
        IEnumerable<ProductType> productTypes;
        if (predicate == default)
            productTypes = await _dbContext.ProductTypes
            .ToListAsync();
        else
            productTypes = await _dbContext.ProductTypes
            .Where(predicate)
            .ToListAsync();

        return productTypes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<ProductType> GetAsync(Expression<Func<ProductType, bool>> predicate)
    {
        ProductType? productTypes = await _dbContext.ProductTypes.FirstOrDefaultAsync(predicate);

        return productTypes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<int> RemoveAsync(ProductType entity)
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
    public async Task<int> UpdateAsync(ProductType entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        int saveChangeReturn = await _dbContext.SaveChangesAsync();

        return saveChangeReturn;
    }
}