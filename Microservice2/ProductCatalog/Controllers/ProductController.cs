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

    public ProductController(ILogger<ProductController> logger,
    IProductItemRepository productItemRepository)
    {
        _logger = logger;
        _productItemRepository = productItemRepository;
    }

    /// <summary>
    /// 取得所有商品資訊及商品的類別
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        // 回傳資料的 List
        List<ProductGetDTO> returnProducts = new List<ProductGetDTO>();

        // 取得所有商品
        IEnumerable<ProductItem> products = await _productItemRepository.GetAllAsync();

        // 處理各別商品資訊
        foreach (var product in products)
        {
            // 建立回傳資料 List 單一個回傳資料的物件
            ProductGetDTO returnProduct = new ProductGetDTO
            {
                Id = product.ProductItemId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                ImageUrl = product.ImageUrl,
            };

            // 將商品加入回傳資料的 List
            returnProducts.Add(returnProduct);
        }

        return Ok(returnProducts);
    }

    /// <summary>
    /// 透過商品 ID 取得特定商品資訊及商品的類別
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetProduct([FromRoute] int id)
    {
        // 透過商品 ID 取得特定一個商品
        ProductItem product = await _productItemRepository.GetAsync(x => x.ProductItemId == id);

        // 如果 ID 對應不到任何商品，回傳 404
        if (product == default)
            return NotFound(new
            {
                Message = "找不到商品"
            });

        // 建立回傳的物件
        ProductGetDTO returnProduct = new ProductGetDTO
        {
            Id = product.ProductItemId,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Quantity = product.Quantity,
            ImageUrl = product.ImageUrl,
        };

        return Ok(returnProduct);
    }

    /// <summary>
    /// 建立商品資訊及商品的類別
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateParam param)
    {
        // 建立一個新的商品物件，帶入新增的商品資訊
        ProductItem newProduct = new ProductItem
        {
            Name = param.Name,
            Description = param.Description,
            Price = param.Price,
            Quantity = param.Quantity,
            ImageUrl = param.ImageUrl,
        };

        // 新增商品至資料庫
        await _productItemRepository.AddAsync(newProduct);

        // 回傳新增的內容
        ProductGetDTO returnCreateValue = new ProductGetDTO
        {
            Id = newProduct.ProductItemId,
            Name = newProduct.Name,
            Description = newProduct.Description,
            Price = newProduct.Price,
            Quantity = newProduct.Quantity,
            ImageUrl = newProduct.ImageUrl,
        };
        return Ok(returnCreateValue);
    }

    /// <summary>
    /// 透過商品 ID 更新商品資訊及類別
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="param"></param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductUpdateParam param)
    {
        // 取得在資料庫中的商品資訊
        ProductItem existedProduct = await _productItemRepository.GetAsync(x => x.ProductItemId == id);

        // 如果 ID 對應不到任何商品，回傳 404
        if (existedProduct == null)
            return NotFound(new
            {
                Message = "找不到商品"
            });

        // 更新商品資訊
        existedProduct.Name = param.Name;
        existedProduct.Description = param.Description;
        existedProduct.Price = param.Price;
        existedProduct.Quantity = param.Quantity;
        existedProduct.ImageUrl = param.ImageUrl;
        await _productItemRepository.UpdateAsync(existedProduct);

        int existedProductId = existedProduct.ProductItemId;

        // 回傳更新的內容
        ProductGetDTO returnUpdateValue = new ProductGetDTO
        {
            Id = existedProductId,
            Name = existedProduct.Name,
            Description = existedProduct.Description,
            Price = existedProduct.Price,
            Quantity = existedProduct.Quantity,
            ImageUrl = existedProduct.ImageUrl,
        };
        return Ok(returnUpdateValue);
    }

    /// <summary>
    /// 透過商品 ID 刪除商品資訊及類別
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        // 取得在資料庫中的商品資訊
        ProductItem existedProduct = await _productItemRepository.GetAsync(x => x.ProductItemId == id);

        // 如果 ID 對應不到任何商品，回傳 404
        if (existedProduct == null)
            return NotFound(new
            {
                Message = "找不到商品"
            });

        await _productItemRepository.RemoveAsync(existedProduct);

        // 回傳已刪除的商品 ID
        return Ok(id);
    }
}