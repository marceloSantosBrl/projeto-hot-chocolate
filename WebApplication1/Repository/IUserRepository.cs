using WebApplication1.Models;

namespace WebApplication1.Repository;

public interface IUserRepository
{
    public Task<Users> GetUser(string username);
    public Task<ICollection<Users>> GetFollowers(int userId);
    public Task<ICollection<Users>> GetFollowed(int userId);
    public Task<ICollection<Comments>> GetComments(int postId);
    public Task<ICollection<Posts>> GetPosts(int userId);
    public Task<Users> GetAuthor(int postId);
    public Task<Users> GetCommentAuthor(int commentId);
    public Task<ICollection<Comments>> GetUserComments(int userId);
    public Task<ICollection<Posts>> GetUserPosts(int userId);
}