using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Users
{
    [Key] public int Id { get; set; }
    [MaxLength(100)] [Required] public string Username { get; set; } = null!;
    [MaxLength(100)] [Required] public string Email { get; set; } = null!;
    [Required] public ICollection<Posts> Posts = new List<Posts>();
    [Required] public ICollection<Comments> Comments = new List<Comments>();
}