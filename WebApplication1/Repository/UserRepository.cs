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

    public async Task<ICollection<Users>> GetFollowers(int userId)
    {
        var result = await _context
            .Followers
            .Include(f => f.Follower)
            .Where(f => f.FollowedId == userId)
            .Select(u => u.Follower)
            .ToListAsync();
        return result;
    }

    public async Task<ICollection<Users>> GetFollowed(int userId)
    {
        var result = await _context
            .Followers
            .Include(f => f.Followed)
            .Where(f => f.FollowerId == userId)
            .Select(u => u.Followed)
            .ToListAsync();
        return result;
    }

    public async Task<ICollection<Comments>> GetComments(int postId)
    {
        var result = await _context
            .Comments
            .Where(c => c.PostsId == postId)
            .ToListAsync();
        return result;
    }

    public async Task<ICollection<Posts>> GetPosts(int userId)
    {
        var postsModels = await _context
            .Posts
            .Where(u => u.UserId == userId)
            .ToListAsync();
        return postsModels;
    }

    public async Task<Users> GetAuthor(int postId)
    {
        var userModel = await _context
            .Posts
            .Where(p => p.Id == postId)
            .Include(p => p.User)
            .Select(p => p.User)
            .FirstAsync();
        return userModel;
    }

    public async Task<Users> GetCommentAuthor(int commentId)
    {
        var userModel = await _context
            .Comments
            .Where(c => c.Id == commentId)
            .Include(c => c.User)
            .Select(c => c.User)
            .FirstAsync();
        return userModel;
    }

    public async Task<ICollection<Comments>> GetUserComments(int userId)
    {
        var comments = await _context
            .Comments
            .Where(c => c.UserId == userId)
            .ToListAsync();
        return comments;
    }

    public async Task<ICollection<Posts>> GetUserPosts(int userId)
    {
        var posts = await _context
            .Posts
            .Where(c => c.UserId == userId)
            .ToListAsync();
        return posts;
    }
}