using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Data;
using ProductCatalog.Models.DTOs;
using ProductCatalog.Models.Params;
using ProductCatalog.Models.Repositories.Interfaces;

namespace ProductCatalog.Controllers;

/// <summary>
/// 商品資訊及商品的類別
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductItemRepository _productItemRepository;
    private readonly IProductTypeRepository _productTypeRepository;

    public ProductController(ILogger<ProductController> logger,
    IProductItemRepository productItemRepository,
    IProductTypeRepository productTypeRepository)
    {
        _logger = logger;
        _productItemRepository = productItemRepository;
        _productTypeRepository = productTypeRepository;
    }

    /// <summary>
    /// 取得所有商品資訊及商品的類別
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        List<ProductGetAllDTO> returnProducts = new List<ProductGetAllDTO>();
        IEnumerable<ProductItem> products = await _productItemRepository.GetAllAsync();
        
        foreach(var product in products) {
            ProductGetAllDTO returnProduct = new ProductGetAllDTO { 
                Id = product.ProductItemId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
            };
            IEnumerable<ProductType> productTypes = await _productTypeRepository.GetAllAsync(x => true);
            returnProduct.ProductType = productTypes.Select(x => x.Name);
            returnProducts.Add(returnProduct);
        }

        return Ok(returnProducts);
    }

    /// <summary>
    /// 透過商品 ID 取得特定商品資訊及商品的類別
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        var product = await _productItemRepository.GetAsync(x => x.ProductItemId == id);
        return Ok(product);
    }

    /// <summary>
    /// 建立商品資訊及商品的類別
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateParam param)
    {
        
        return Ok();
    }

    /// <summary>
    /// 透過商品 ID 更新商品資訊及類別
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int Id, [FromBody] ProductUpdateParam param)
    {

        return Ok();
    }

    /// <summary>
    /// 透過商品 ID 刪除商品資訊及類別
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {

        return Ok();
    }
}