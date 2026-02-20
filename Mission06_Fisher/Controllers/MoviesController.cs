using Mission06_Fisher.Data;
using Mission06_Fisher.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Fisher.Controllers;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _context;
    public MoviesController(ApplicationDbContext context) => _context = context;

    public IActionResult Index()
    {
        var movies = _context.Movies
            .OrderBy(m => m.Title)
            .ToList();
        
        return View(movies);
    }
    
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _context.Movies.Add(movie);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound();

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        _context.Movies.Update(movie);
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
            return NotFound();

        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.Find(id);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        
        return RedirectToAction("Index");
    }
}