using Microsoft.AspNetCore.Mvc;
using AlbumProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbumProject.Data.Migrations;
using AlbumProject.Data;
using NuGet.ContentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

[Route("api/[controller]")]
[ApiController]
public class SingerApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public SingerApiController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: api/<ValuesController>
    [HttpGet]
    public async Task<ActionResult<List<Singer>>> Get()
    {
        var y = await _context.Singers.ToListAsync();
        if (y is null)
        {
            return NoContent();
        }
        return y;

    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Singer>> Get(int id)
    {
        var y = await _context.Singers.FirstOrDefaultAsync(x => x.SingerId == id);
        if (y is null)
        {
            return NoContent();
        }
        return y;
    }
}