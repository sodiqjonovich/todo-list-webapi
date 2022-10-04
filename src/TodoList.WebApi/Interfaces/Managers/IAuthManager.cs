using TodoList.WebApi.Models;

namespace TodoList.WebApi.Interfaces.Managers
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
