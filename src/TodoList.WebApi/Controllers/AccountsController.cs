using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountsController(IAccountService service)
        {
            this._service = service;
        }

        [HttpPost("registr"), AllowAnonymous]
        public async Task<IActionResult> RegistrAsync([FromForm] UserCreateViewModel userCreateViewModel)
            => Ok(await _service.RegistrAsync(userCreateViewModel));

        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] UserLoginViewModel userLoginViewModel)
            => Ok(new {Token=await _service.LoginAsync(userLoginViewModel) });
    }
}
