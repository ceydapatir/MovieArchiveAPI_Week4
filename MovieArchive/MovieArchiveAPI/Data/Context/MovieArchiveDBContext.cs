using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieArchiveAPI.Data.Context
{
    public class MovieArchiveDBContext : DbContext, IMovieArchiveDBContext
    {
        public MovieArchiveDBContext(DbContextOptions<MovieArchiveDBContext> options) : base(options) {}

        public DbSet<Movie> Movies { get; set;}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}