using Microsoft.EntityFrameworkCore;

namespace ASP260908.Models;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; } = default!;
}
