using AlbumProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumProject.Models;
using System;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace AlbumProject.Controllers
{
    public class AlbumController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AlbumController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            List<Album> a = _context.Albums.Include(aa => aa.Sing).ToList();

            var album = (from aa in _context.Albums where aa.Sing != null select aa).ToList();
            return View(album);
        }
        //public IActionResult Create()
        //{

        //    return View();
        //}
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([Bind("AlbumId,AlbumTitle,AlbumSongCount,AlbumGenre,AlbumScore,AlbumYear,SingerId")] Album album)
        {
            _context.Add(album);
            _context.SaveChanges();
            ViewData["SingerId"] = new SelectList(_context.Singers, "SingerId", "SingerName", album.SingerId); 
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()

        {
            ViewData["SingerId"] = new SelectList(_context.Singers, "SingerId", "SingerName");
            return View();
        }

        
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("SingerId,SingerName,SingerLName,SingerNationality,SingerAge")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Albums'is null.");
            }
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
        
    }
}
