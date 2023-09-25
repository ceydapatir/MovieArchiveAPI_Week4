using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Context;

namespace MovieArchiveAPI.Applications.GenreOperations.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        private readonly MovieArchiveDBContext _context;

        public DeleteGenreCommand(MovieArchiveDBContext context, int genreId){
            _context = context;
            GenreId = genreId;
        }

        // Data with GenreId is searched, if it exists and does not belong to a recorded movie, it is deleted, otherwise it gives an error.
        public void Handle(){
            var genre = _context.Genres.Where(i => i.GenreId == GenreId).SingleOrDefault();
            if(genre is null)
                throw new InvalidOperationException("The genre doesn't exist.");
            else{
                var movie = _context.Movies.Where(i => i.GenreId == GenreId).FirstOrDefault();
                if(movie is not null)
                    throw new InvalidOperationException("The genre cannot be deleted from the system while there are movies registered to the genre.");
                else
                    _context.Genres.Remove(genre);
                    _context.SaveChanges();
            }
        }
    }
}