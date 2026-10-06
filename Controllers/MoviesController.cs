using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASP260908.Models;

namespace ASP260908.Controllers;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ~/movies/[index]
    public async Task<IActionResult> Index(string searchString)    
    {
        if (_context.Movies == null) return Problem("Entity ApplicationDbContext is null");

        var movies = _context.Movies.Select(m => m);

        if (!string.IsNullOrEmpty(searchString))
        {
            movies = movies.Where(m => m.Title!.ToUpper().Contains(searchString.ToUpper()));
        }

        return View(await movies.ToListAsync());
    }

    // GET: ~/movies/details/{id:int}
    public async Task<IActionResult> Details(int? id)
    {
        if (id is null) return NotFound();
        
        var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
        
        if (movie is null) return NotFound();
        
        return View(movie);
    }

    // GET: ~/movies/create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ~/movies/create
    [HttpPost][ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: ~/movies/edit/{id}
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return NotFound();

        var movie = await _context.Movies.FindAsync(id);

        if (movie is null) return NotFound();

        return View(movie);
    }

    // POST: ~/movies/edit/{id}
    [HttpPost][ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
    {
        if (id != movie.Id) return NotFound();
        
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(movie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movie.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }

    // GET: ~/movies/delete/{id}
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return NotFound();
        var movie = await _context.Movies.SingleOrDefaultAsync(m => m.Id == id);
        if (movie is null) return NotFound();

        return View(movie);
    }

    // POST: ~/movies/delete/{id}
    [HttpPost, ActionName("Delete")] [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie is not null) _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    private bool MovieExists(int? id)
    {
        return _context.Movies.Any(e => e.Id == id);
    }
}
