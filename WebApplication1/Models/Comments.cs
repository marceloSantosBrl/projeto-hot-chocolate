using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Comments
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength] public string Comment { get; set; } = null!;
    [Required] public Users User { get; set; } = null!;
    [Required] [ForeignKey("User")] public int UserId { get; set; }

    [Required] public Posts Posts { get; set; } = null!;
    [Required] [ForeignKey("Posts")] public int PostsId { get; set; }
}