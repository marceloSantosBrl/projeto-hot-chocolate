using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Schema;
using WebApplication1.Schema.CommentType;
using WebApplication1.Schema.PostType;
using WebApplication1.Schema.UserType;

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

    public async Task<ICollection<User>> GetFollowers(User user)
    {
        var id = user.Id;
        var usersModels = await _userRepository.GetFollowers(id);
        return usersModels
            .Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                Username = u.Username
            })
            .ToList();
    }

    public async Task<ICollection<User>> GetFollowed(User user)
    {
        var id = user.Id;
        var usersModels = await _userRepository.GetFollowed(id);
        return usersModels
            .Select(u => new User
            {
                Id = u.Id,
                Email = u.Email,
                Username = u.Username
            })
            .ToList();
    }

    public async Task<ICollection<Comment>> GetCommets(Post post)
    {
        var commentsModel = await _userRepository
            .GetComments(post.Id);
        return commentsModel.Select(c => new Comment()
        {
            Id = c.Id,
            Content = c.Comment
        }).ToList();
    }

    public async Task<ICollection<Post>> GetPosts(User user)
    {
        var postsModel = await _userRepository
            .GetPosts(user.Id);
        return postsModel
            .Select(p =>
            {
                return new Post
                {
                    Id = p.Id,
                };
            })
            .ToList();
    }

    public async Task<User> GetAuthor(Post post)
    {
        var id = post.Id;
        var userModel = await _userRepository.GetAuthor(id);
        return new User
        {
            Username = userModel.Username,
            Email = userModel.Email,
            Id = userModel.Id
        };
    }

    public async Task<User> GetCommentAuthor(Comment comment)
    {
        var id = comment.Id;
        var userModel = await _userRepository.GetCommentAuthor(id);
        return new User
        {
            Username = userModel.Username,
            Email = userModel.Email,
            Id = userModel.Id
        };
    }

    public async Task<ICollection<Comment>> GetUserComments(User user)
    {
        var commentsModel = await _userRepository.GetUserComments(user.Id);
        return commentsModel.Select(c => new Comment
        {
            Id = c.Id,
            Content = c.Comment,
        }).ToList();
    }

    public Task<ICollection<Post>> GetUserPosts(User user)
    {
        throw new NotImplementedException();
    }
}