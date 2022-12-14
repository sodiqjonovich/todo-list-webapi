using TodoList.WebApi.Exceptions;
using TodoList.WebApi.Interfaces.Managers;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Models;
using TodoList.WebApi.Security;
using TodoList.WebApi.ViewModels.Users;

namespace TodoList.WebApi.Services;

public class AccountService : IAccountService
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;
    private readonly IAuthManager _authmanager;

    public AccountService(IUserRepository repository,
        IFileService fileService,
        IAuthManager authManager)
    {
        this._repository = repository;
        this._fileService = fileService;
        this._authmanager = authManager;
    }

    public async Task<string> LoginAsync(UserLoginViewModel userLoginViewModel)
    {
        var user = await _repository.FindByEmail(userLoginViewModel.Email);
        if (user is null) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Email is wrong!");
        
        var hasherResult = PasswordHasher.Verify(userLoginViewModel.Password, user.Salt, user.PasswordHash);
        if(hasherResult is false) throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Password is wrong!");

        return _authmanager.GenerateToken(user);
    }

    public async Task<bool> RegistrAsync(UserCreateViewModel userCreateViewModel)
    {
        var validateUser = await _repository.FindByEmail(userCreateViewModel.Email);
        if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This email is already exist");

        validateUser = await _repository.FindByPhoneNumber(userCreateViewModel.PhoneNumber);
        if (validateUser is not null) throw new StatusCodeException(System.Net.HttpStatusCode.Conflict, "This phone number is already exist");

        var user = (User) userCreateViewModel;
        if (userCreateViewModel.Image is not null)
            user.ImagePath = await _fileService.SaveImageAsync(userCreateViewModel.Image);
        var hasherResult = PasswordHasher.Hash(userCreateViewModel.Password);
        user.Salt = hasherResult.Salt;
        user.PasswordHash = hasherResult.Hash;
        await _repository.CreateAsync(user);
        return true;
    }
}
