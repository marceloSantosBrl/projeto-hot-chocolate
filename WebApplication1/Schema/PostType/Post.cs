using WebApplication1.Models;
using WebApplication1.Schema.UserType;

namespace WebApplication1.Schema.PostType;

public class Post
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public User Author { get; set; } = null!;
    public ICollection<Comments> CommentsCollection { get; set; } = null!;
}