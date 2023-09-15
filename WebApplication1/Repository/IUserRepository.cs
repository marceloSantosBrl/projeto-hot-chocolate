using WebApplication1.Models;
namespace WebApplication1.Repository;

public interface IUserRepository
{
    public Task<Users> GetUser(string username);
}