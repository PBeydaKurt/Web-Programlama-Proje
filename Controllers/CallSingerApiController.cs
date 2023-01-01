using Microsoft.AspNetCore.Mvc;
using AlbumProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlbumProject.Controllers
{
    public class CallSingerApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Singer> Singers = new List<Singer>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7099/api/SingerApi");
            string resString = await response.Content.ReadAsStringAsync();
            Singers = JsonConvert.DeserializeObject<List<Singer>>(resString);
            return View(Singers);
        }
    }
}
