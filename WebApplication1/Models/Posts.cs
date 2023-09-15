using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Posts
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength] public string Content { get; set; } = null!;
    [Required] public ICollection<Comments> Comments { get; set; } = null!;
    [Required] public Users User { get; set; } = null!;
    [Required] [ForeignKey("User")] public int UserId { get; set; }
}