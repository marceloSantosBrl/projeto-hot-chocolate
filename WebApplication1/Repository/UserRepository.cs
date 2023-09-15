using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Repository;

public class UserRepository: IUserRepository
{
    private readonly UserContext _context;

    public UserRepository(UserContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<Users> GetUser(string username)
    {
        return await _context.Users
            .FirstAsync(u => u.Username == username);
    }
}