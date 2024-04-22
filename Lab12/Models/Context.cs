using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public DbSet<Company> Companies { get; set; } = null;

    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }
}