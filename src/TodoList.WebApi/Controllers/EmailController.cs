using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.ViewModels.Common;

namespace TodoList.WebApi.Controllers
{
    [Route("api/email/messages")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            this._emailService = emailService;
        }
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] EmailMessage emailMessage)
        {
            await _emailService.SendAsync(emailMessage);
            return Ok();
        }
    }
}
