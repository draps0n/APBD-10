using APBD_10.Exceptions;
using APBD_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_10.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private IAccountService _accountService = accountService;

    [HttpGet("accountId:int")]
    public async Task<IActionResult> GetAccountDataByIdAsync(int accountId)
    {
        try
        {
            return Ok(await _accountService.GetAccountDataByIdAsync(accountId));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}