using System.Linq.Expressions;
using ProductCatalog.Data;

namespace ProductCatalog.Models.Repositories.Interfaces;
/// <summary>
/// Interface Repository
/// </summary>
public interface IProductItemRepository
{
    /// <summary>
    /// 新增實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> AddAsync(ProductItem entity);

    /// <summary>
    /// 取得全部實體
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductItem>> GetAllAsync();

    /// <summary>
    /// 透過條件取得單一實體
    /// </summary>
    /// <param name="predicate">查詢條件</param>
    /// <returns></returns>
    Task<ProductItem> GetAsync(Expression<Func<ProductItem, bool>> predicate);

    /// <summary>
    /// 刪除一個實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> RemoveAsync(ProductItem entity);

    /// <summary>
    /// 更新一個實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> UpdateAsync(ProductItem entity);
}