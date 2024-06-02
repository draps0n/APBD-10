using APBD_10.RequestModels;
using APBD_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController(IProductService productService) : ControllerBase
{
    private IProductService _productService = productService;

    [HttpPost]
    public async Task<IActionResult> AddNewProductAsync([FromBody] PostProductRequestModel request)
    {
        foreach (var categoryId in request.ProductCategories)
        {
            if (!await _productService.DoesCategoryOfIdExist(categoryId))
            {
                return NotFound($"Category of id:{categoryId} does not exist");
            }
        }

        var response = await _productService.AddProductAsync(request);

        return StatusCode(StatusCodes.Status201Created, response);
    }
}