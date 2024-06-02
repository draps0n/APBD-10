using APBD_10.Contexts;
using APBD_10.Models;
using APBD_10.RequestModels;
using APBD_10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Services;

public class ProductService(DatabaseContext context) : IProductService
{
    public async Task<bool> DoesCategoryOfIdExist(int categoryId)
    {
        return await context.Categories
            .Where(c => c.CategoryId == categoryId)
            .FirstOrDefaultAsync() != null;
    }

    public async Task<PostProductResponseModel> AddProductAsync(PostProductRequestModel request)
    {
        var newProduct = new Product
        {
            ProductName = request.ProductName,
            ProductWeight = request.ProductWeight,
            ProductWidth = request.ProductWidth,
            ProductHeight = request.ProductHeight,
            ProductDepth = request.ProductDepth
        };

        await context.Products.AddAsync(newProduct);

        foreach (var categoryId in request.ProductCategories)
        {
            await context.ProductsCategories.AddAsync(new ProductCategory
            {
                Product = newProduct,
                CategoryId = categoryId
            });
        }

        await context.SaveChangesAsync();

        return new PostProductResponseModel
        {
            ProductId = newProduct.ProductId,
            ProductName = newProduct.ProductName,
            ProductWeight = newProduct.ProductWeight,
            ProductWidth = newProduct.ProductWidth,
            ProductHeight = newProduct.ProductHeight,
            ProductDepth = newProduct.ProductDepth,
            ProductCategories = request.ProductCategories.Any()
                ? newProduct.ProductsCategories.Select(pc => pc.Category.CategoryName).ToList()
                : []
        };
    }
}