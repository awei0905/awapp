using System.Linq.Expressions;
using ProductCatalog.Data;

namespace ProductCatalog.Models.Repositories.Interfaces;
/// <summary>
/// Interface Repository
/// </summary>
public interface IProductTypeRepository
{
    /// <summary>
    /// 新增實體
    /// </summary>
    /// <param name="entities">實體</param>
    Task<int> AddRangeIfNotExistedAsync(IEnumerable<ProductType> entities);

    /// <summary>
    /// 取得全部實體
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductType>> GetAllAsync(Expression<Func<ProductType, bool>> predicate);
}