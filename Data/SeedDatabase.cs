using ASP260908.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP260908.Data;

public static class SeedDatabase
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using ApplicationDbContext _context = new(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
        
        if (_context.Movies.Any()) return;

        _context.Movies.AddRange(
            new Movie
            {
                //01
                Title = "Kill Bill vol. 1",
                ReleaseDate = new(2003, 10, 16),
                Genre = "Action",
                Price = 1500M,
            },
            new Movie
            {
                //02
                Title = "Kill Bill vol. 2",
                ReleaseDate = new(2004, 04, 29),
                Genre = "Action",
                Price = 2000M,
            },
            new Movie
            {
                //03
                Title = "Cloud Atlas",
                ReleaseDate = new(2012, 11, 22),
                Genre = "Drama",
                Price = 2700M,
            },
            new Movie
            {
                //04
                Title = "The Shawshark Redemption",
                ReleaseDate = new(1994, 05, 25),
                Genre = "Drama",
                Price = 1000M,
            },
            new Movie
            {
                //05
                Title = "The Lord of the Rings: The Two Towers",
                ReleaseDate = new(2002, 01, 09),
                Genre = "Adventure",
                Price = 2200M,
            },
            new Movie
            {
                //06
                Title = "The Matrix",
                ReleaseDate = new(1999, 08, 05),
                Genre = "Action",
                Price = 1800M,
            },
            new Movie
            {
                //07
                Title = "One Flew Over the Cuckoo's Nest",
                ReleaseDate = new(1975, 05, 19),
                Genre = "Drama",
                Price = 1000M,
            });
        _context.SaveChanges();
    }
}
