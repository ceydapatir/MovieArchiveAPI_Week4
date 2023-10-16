using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieArchiveAPI.Data.Entities;

namespace MovieArchiveAPI.Data.Context
{
    public interface IMovieArchiveDBContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        int SaveChanges();
    }
}