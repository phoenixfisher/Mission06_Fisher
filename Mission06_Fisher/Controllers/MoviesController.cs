using Mission06_Fisher.Data;
using Mission06_Fisher.Models;

namespace Mission06_Fisher.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class MoviesController : Controller
{
    private readonly ApplicationDbContext _db;
    public MoviesController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _db.Categories.OrderBy(c => c.Name).ToListAsync();
        ViewBag.Directors = await _db.Directors.OrderBy(d => d.Name).ToListAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CategoryId,Title,Year,DirectorId,Rating,Edited,LentTo,Notes")] Movie movie)
    {
        // server side validation: required fields are enforced by data annotations
        if (ModelState.IsValid)
        {
            _db.Movies.Add(movie);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        ViewBag.Categories = await _db.Categories.OrderBy(c => c.Name).ToListAsync();
        ViewBag.Directors = await _db.Directors.OrderBy(d => d.Name).ToListAsync();
        return View(movie);
    }
}