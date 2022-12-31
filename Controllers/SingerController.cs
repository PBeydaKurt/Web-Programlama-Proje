/*using AlbumProject.Data;
using Microsoft.AspNetCore.Mvc;
using AlbumProject.Models;

using Microsoft.EntityFrameworkCore;

namespace AlbumProject.Controllers
{
    public class SingerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Singer> a=_context.Singers.ToList();
            return View(a);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("SingerName,SingerLName,SingerNationality,SingerAge")]Singer a)
        {
            _context.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

*/
/*
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlbumProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AlbumProject.Controllers
    
{
    public class SingerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SingerController(ApplicationDbContext context)
        {
            _context = context;
        }
        static List<Singer> singers = new List<Singer>();
        // GET: OgrenciController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return View(singers);
        }
        // GET: OgrenciController/Details/5
        public ActionResult Details(int id)
        {
            Singer gelen = new Singer();
            // gelen = ogrenciler.Find(x => x.OgrNo = id);
            foreach (var sngr in singers)
            {
                if (Convert.ToInt32(sngr.SingerId) == id)
                {
                    // ogr.OgrAd=gelen.
                    gelen = sngr;
                    break;
                }

            }
            if (gelen.SingerName is null)
                return View("Hata");
            return View(gelen);
        }

        // GET: OgrenciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OgrenciController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Singer sngr)
        {
            if (ModelState.IsValid)
            {
                singers.Add(sngr);
                TempData["sngr"] = sngr.SingerName + " Adlı şarkıcı Eklendi";
                return RedirectToAction("List");
                _context.Add(sngr);
                _context.SaveChanges();
               
            }
            else
            {
                return View("Hata");
            }
        }

        // GET: OgrenciController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OgrenciController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OgrenciController/Delete/5
        public ActionResult Delete(int id)
        {
            Singer silinecek = new Singer();
            foreach (var sngr in singers)
            {
                if (Convert.ToInt32(sngr.SingerId) == id)
                {
                    silinecek = sngr;
                    break;
                }
            }
            if (silinecek.SingerName is null)
            {
                return View("Hata");
            }
            else
            {
                TempData["ogr"] = silinecek.SingerName + " adlı öğrenci silindi";
                singers.Remove(silinecek);
                return RedirectToAction("List");
            }



        }

        // POST: OgrenciController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
*/

using AlbumProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlbumProject.Models;

namespace AlbumProject.Controllers
{
    public class SingerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SingerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Singer> a = _context.Singers.ToList();
            return View(a);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("SingerName,SingerLName,SingerNationality,SingerAge")] Singer a)
        {
            _context.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Singers == null)
            {
                return NotFound();
            }

            var subject = await _context.Singers
                .FirstOrDefaultAsync(m => m.SingerId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Singers == null)
            {
                return NotFound();
            }

            var subject = await _context.Singers.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SingerId,SingerName,SingerLName,SingerNationality,SingerAge")] Singer subject)
        {
            if (id != subject.SingerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SingerId))
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
            return View(subject);
        }
        //**************


        // GET: Subject1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Singers == null)
            {
                return NotFound();
            }

            var subject = await _context.Singers
                .FirstOrDefaultAsync(m => m.SingerId == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subject1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Singers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subjects'  is null.");
            }
            var subject = await _context.Singers.FindAsync(id);
            if (subject != null)
            {
                _context.Singers.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Singers.Any(e => e.SingerId == id);
        }
    }
}

