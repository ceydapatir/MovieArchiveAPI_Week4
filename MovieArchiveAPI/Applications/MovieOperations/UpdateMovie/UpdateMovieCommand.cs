using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.MovieOperations.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public MovieDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateMovieCommand(MovieArchiveDBContext context, IMapper mapper, int movieId, MovieDTO model)
        {
            _context = context;
            _mapper = mapper;
            MovieId = movieId;
            Model = model;
        }

        // Data with MovieId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.MovieId == MovieId).SingleOrDefault();
            if(movie is null)
                throw new InvalidOperationException("The movie doesn't exist.");
            else
                movie = _mapper.Map(Model,movie);  // Reverse movie with ViewModel
                movie.Director = _context.Directors.Where(i => i.DirectorId == movie.DirectorId).Single();
                movie.Genre = _context.Genres.Where(i => i.GenreId == movie.GenreId).Single();
                _context.SaveChanges();
        }
    }
}