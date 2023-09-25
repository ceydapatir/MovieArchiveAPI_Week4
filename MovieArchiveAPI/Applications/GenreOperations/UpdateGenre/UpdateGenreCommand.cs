using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.GenreOperations.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public GenreDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateGenreCommand(MovieArchiveDBContext context, IMapper mapper, int genreId, GenreDTO model)
        {
            _context = context;
            _mapper = mapper;
            GenreId = genreId;
            Model = model;
        }

        // Data with GenreId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(){
            var genre = _context.Genres.Where(i => i.Name.Contains(Model.Name,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if(genre is not null) // Throw an error if the new name already exists in the system
                throw new InvalidOperationException("The genre already exists.");
            else
                genre = _context.Genres.Where(i => i.GenreId == GenreId).FirstOrDefault();
                if(genre is null)
                    throw new InvalidOperationException("The genre doesn't exist.");
                else
                    genre = _mapper.Map(Model,genre);  // Reverse movie with ViewModel
                    _context.SaveChanges();
        }
    }
}