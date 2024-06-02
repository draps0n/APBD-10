using APBD_10.ResponseModels;

namespace APBD_10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountDataByIdAsync(int accountId);
}