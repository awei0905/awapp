using System.Linq.Expressions;
using ProductCatalog.Data;

namespace ProductCatalog.Models.Repositories.Interfaces;
/// <summary>
/// Interface Repository
/// </summary>
public interface IProductItemTypeRepository
{
    /// <summary>
    /// 新增實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> AddAsync(ProductItemType entity);

    /// <summary>
    /// 取得全部實體
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<ProductItemType>> GetAllAsync(int productionItemId);

    /// <summary>
    /// 刪除一個實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> RemoveAsync(ProductItemType entity);

    /// <summary>
    /// 更新一個實體
    /// </summary>
    /// <param name="entity">實體</param>
    Task<int> UpdateAsync(ProductItemType entity);
}