using WebApplication1.Schema.UserType;

namespace WebApplication1.Schema.CommentType;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public User Author { get; set; } = null!;
}