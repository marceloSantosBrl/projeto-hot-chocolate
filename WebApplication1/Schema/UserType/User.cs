using WebApplication1.Schema.CommentType;
using WebApplication1.Schema.PostType;

namespace WebApplication1.Schema.UserType;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
     public string Email { get; set; } = null!;
     public ICollection<Post> Posts { get; set; } = null!;
     public ICollection<Comment> Comments { get; set; } = null!;
     public ICollection<User> Followers { get; set; } = null!;
     public ICollection<User> Followed { get; set; } = null!;
}