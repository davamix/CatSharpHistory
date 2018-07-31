using System;
using Microsoft.EntityFrameworkCore;

using CatSharp.Data.Entities;

namespace CatSharp.Data
{
    public class CatSharpContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Weight> Weight { get; set; }

        public CatSharpContext(DbContextOptions<CatSharpContext> options)
        : base(options)
        {

        }
    }
}
