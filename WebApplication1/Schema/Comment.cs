namespace WebApplication1.Schema;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    public int AuthorId { get; set; }
}