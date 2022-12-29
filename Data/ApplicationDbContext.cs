using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlbumProject.Models;
using System;

namespace AlbumProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}