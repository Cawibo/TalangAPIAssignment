using Microsoft.EntityFrameworkCore;

namespace WhatCatAmI.Models
{
    public class CatContext : DbContext
    {
        public CatContext(DbContextOptions<CatContext> options) : base(options)
        {
        }

        public DbSet<CatItem> CatItems { get; set; }
    }
}