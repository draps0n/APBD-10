using APBD_10.RequestModels;
using APBD_10.ResponseModels;

namespace APBD_10.Services;

public interface IProductService
{
    Task<bool> DoesCategoryOfIdExist(int categoryId);
    Task<PostProductResponseModel> AddProductAsync(PostProductRequestModel request);
}