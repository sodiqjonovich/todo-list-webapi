using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> RegistrAsync(UserCreateViewModel userCreateViewModel);

        Task<string> LoginAsync(UserLoginViewModel userLoginViewModel);
    }
}
