using ImageGame.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGame.Data
{
    public class ImageGameDbContext : DbContext
    {
        public ImageGameDbContext(DbContextOptions<ImageGameDbContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
