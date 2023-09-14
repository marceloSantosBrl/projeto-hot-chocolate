using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public class Context: DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Comments> Comments { get; set; } = null!;
    public DbSet<Followers> Followers { get; set; } = null!;
    public DbSet<Posts> Posts { get; set; } = null!;
    public DbSet<Users> Users { get; set; } = null!;

    public Context()
    {
        
    }

    public Context(IConfiguration configuration)
    {
        _configuration = configuration ?? 
                         throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source=mydb.db");
    }
}