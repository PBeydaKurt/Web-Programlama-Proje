using AlbumProject.Data;
using Microsoft.AspNetCore.Mvc;
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
            List<Singer> a=_context.Singers.ToList();
            return View(a);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("SingerName","SingerLName")]Singer a)
        {
            _context.Add(a);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
