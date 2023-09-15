using WebApplication1.Models;
using WebApplication1.Schema;
using WebApplication1.Schema.CommentType;
using WebApplication1.Schema.PostType;
using WebApplication1.Schema.UserType;

namespace WebApplication1.Services;

public interface IUserService
{
    public Task<User> GetUser(string username);

    public Task<ICollection<User>> GetFollowers(User user);
    public Task<ICollection<User>> GetFollowed(User user);
    public Task<ICollection<Comment>> GetCommets(Post post);
    public Task<ICollection<Post>> GetPosts(User user);
    public Task<User> GetAuthor(Post post);
    public Task<User> GetCommentAuthor(Comment comment);
    public Task<ICollection<Comment>> GetUserComments(User user);
    public Task<ICollection<Post>> GetUserPosts(User user);

}