using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TourOfHeroes.Core.Entity;

namespace TourOfHeroes.Infrastructure.SQL.Data.Database
{
    public class PhotoDBContext : DbContext
    {
        public PhotoDBContext(DbContextOptions<PhotoDBContext> options) : base(options)
        {
        }

        public DbSet<Photo> Photo { get; set; }
    }
}
