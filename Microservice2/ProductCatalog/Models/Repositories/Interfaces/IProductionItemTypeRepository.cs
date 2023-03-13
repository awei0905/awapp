using System.Linq.Expressions;
using ProductCatalog.Data;

namespace ProductCatalog.Models.Repositories.Interfaces;
/// <summary>
/// Interface Repository
/// </summary>
public interface IProductItemTypeRepository
{
    /// <summary>
    /// 取得全部實體
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductItemType>> GetAllAsync(int productionItemId);

    /// <summary>
    /// 刪除一個實體
    /// </summary>
    /// <param name="entities">實體</param>
    Task<int> RemoveRangeAsync(IEnumerable<ProductItemType> entities);

    /// <summary>
    /// 更新一個實體
    /// </summary>
    /// <param name="entities">實體</param>
    Task<int> AddRangeAsync(IEnumerable<ProductItemType> entities);
}