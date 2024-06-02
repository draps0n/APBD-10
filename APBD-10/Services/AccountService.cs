using APBD_10.Contexts;
using APBD_10.Exceptions;
using APBD_10.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Services;

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountDataByIdAsync(int accountId)
    {
        var result = await context.Accounts
            .Where(e => e.AccountId == accountId)
            .Select(account => new GetAccountResponseModel
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                Role = account.Role.RoleName,
                Cart = account.ShoppingCarts.Select(cart => new CartItem
                {
                    ProductId = cart.ProductId,
                    ProductName = cart.Product.ProductName,
                    Amount = cart.Amount
                })
            })
            .FirstOrDefaultAsync();

        if (result is null)
        {
            throw new NotFoundException($"Account of id:{accountId} does not exist");
        }
        
        return result;

    }
}