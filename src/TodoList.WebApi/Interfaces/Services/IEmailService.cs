using TodoList.WebApi.ViewModels.Common;

namespace TodoList.WebApi.Interfaces.Services
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessage emailMessage);
    }
}
