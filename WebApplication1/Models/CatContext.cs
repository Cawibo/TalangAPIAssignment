using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CatContext : DbContext
    {
        public CatContext(DbContextOptions<CatContext> options) :base(options) { }

        public DbSet<CatItem> CatItems { get; set; }
    }
}
