namespace WebApplication1.Schema;

public class Post
{
    // id: ID!
    // content: String!
    // author: User! # Quem criou o post
    // comments: [Comment] # Comentários do
    // post
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public 
}