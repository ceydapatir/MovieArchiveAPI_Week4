using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieArchiveAPI.Data.Context;

namespace MovieArchiveAPI.Applications.DirectorOperations.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly MovieArchiveDBContext _context;

        public DeleteDirectorCommand(MovieArchiveDBContext context, int directorId){
            _context = context;
            DirectorId = directorId;
        }

        // Data with DirectorId is searched, if it exists and does not belong to a recorded movie, it is deleted, otherwise it gives an error.
        public void Handle(){
            var director = _context.Directors.Where(i => i.DirectorId == DirectorId).SingleOrDefault();
            if(director is null)
                throw new InvalidOperationException("The director doesn't exist.");
            else{
                var movie = _context.Movies.Where(i => i.DirectorId == DirectorId).FirstOrDefault();
                if(movie is not null)
                    throw new InvalidOperationException("The director cannot be deleted from the system while there are movies registered to the director.");
                else
                    _context.Directors.Remove(director);
                    _context.SaveChanges();
            }
                
        }
    }
}