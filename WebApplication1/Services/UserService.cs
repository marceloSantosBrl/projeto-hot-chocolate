using WebApplication1.Repository;
using WebApplication1.Schema;

namespace WebApplication1.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }
    
    public async Task<User> GetUser(string username)
    {
        var userModel = await _userRepository.GetUser(username);
        var userSchema = new User()
        {
            Id = userModel.Id,
            Email = userModel.Email,
            Username = userModel.Username
        };
        return userSchema;
    }
}