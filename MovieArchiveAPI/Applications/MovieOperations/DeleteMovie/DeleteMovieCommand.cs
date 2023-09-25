using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Context;

namespace MovieArchiveAPI.Applications.MovieOperations.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly MovieArchiveDBContext _context;

        public DeleteMovieCommand(MovieArchiveDBContext context, int movieId){
            _context = context;
            MovieId = movieId;
        }

        // Data with MovieId is searched, if any it is deleted, otherwise it throws an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.MovieId == MovieId).FirstOrDefault();
            if(movie is null)
                throw new InvalidOperationException("The movie doesn't exist.");
            else
                _context.Movies.Remove(movie);
                _context.SaveChanges();
        }
    }
}