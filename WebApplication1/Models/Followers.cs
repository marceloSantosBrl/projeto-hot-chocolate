using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models;

public class Followers
{
    [Key] public int Id { get; set; }
    [Required] public Users Follower { get; set; } = null!;
    [Required] [ForeignKey(("Follower"))] public int FollowerId { get; set;}
    [Required] public Users Followed { get; set; } = null!;
    [Required] [ForeignKey(("Followed"))] public int FollowedId { get; set;}
    
}
