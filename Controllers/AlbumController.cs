using AlbumProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumProject.Models;
using System;
using System.Drawing;

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

            var assay = (from aa in _context.Albums where aa.Sing != null select aa).ToList();
            return View(assay);
        }
        //public IActionResult Create()
        //{

        //    return View();
        //}
        [HttpPost]
        public IActionResult Create([Bind("AlbumId,AlbumTitle,AlbumSongCount,AlbumGenre,AlbumScore,AlbumYear,SingerId")] Album assay)
        {
            _context.Add(assay);
            _context.SaveChanges();
            ViewData["SingerId"] = new SelectList(_context.Singers, "SingerId", "SingerName", assay.SingerId); 
            return RedirectToAction("Index");
        }
        // GET: Kitap/Create
        public IActionResult Create()
        {
            ViewData["SingerId"] = new SelectList(_context.Singers, "SingerId", "SingerName");
            return View();
        }

        // POST: Kitap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("AssayId,AssayTitle,SubjectId")] Assay assay)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(assay);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectName", assay.SubjectId);
        //    return View(assay);
        //}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var assay = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var assay = await _context.Albums.FindAsync(id);
            if (assay == null)
            {
                return NotFound();
            }
            return View(assay);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SingerId,SingerName,SingerLName,SingerNationality,SingerAge")] Album assay)
        {
            if (id != assay.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(assay.AlbumId))
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
            return View(assay);
        }
        //**************


        // GET: Subject1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var assay = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (assay == null)
            {
                return NotFound();
            }

            return View(assay);
        }

        // POST: Subject1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Assays'  is null.");
            }
            var assay = await _context.Albums.FindAsync(id);
            if (assay != null)
            {
                _context.Albums.Remove(assay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
        //public IActionResult Index()
        //{
        //    List<Assay> a = _context.Assays.Include(aa => aa.Subj).ToList();

        //    return View(a);
        //}
        //
        ///lütfen bu da düzgün çalıssin 
    }
}
