using WebApplication1.Schema;

namespace WebApplication1.Services;

public interface IUserService
{
    public Task<User> GetUser(string username);

}