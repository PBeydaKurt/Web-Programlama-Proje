using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebProgramalamaProjem.Data;
using WebProgramalamaProjem.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace WebProgramalamaProjem.Controllers
{
    public class HogwartsAvailableController : Controller
    {
        ApplicationDbContext dbContext;
        public HogwartsAvailableController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowHogwartsA()
        {
            ViewData["HogwartsAvailableCatalog"] = new SelectList(dbContext.HogwartsAvailables, "HogwartsAvailableCatalog", "HogwartsAvailableCatalog");
            var hayvanlar = dbContext.HogwartsAvailables.ToList();
            return View(hayvanlar);
        }

    }
}
