using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.MovieOperations.CreateMovie
{
    public class CreateMovieCommand
    {
        public MovieDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;

        public CreateMovieCommand(IMovieArchiveDBContext context, IMapper mapper, MovieDTO model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // If there is no other movie with the same name, it will be added and if there is, it will throw an error.
        public void Handle(){
            var movie = _context.Movies.Where(i => i.Name == Model.Name).SingleOrDefault();
            if(movie is not null)
                throw new InvalidOperationException("The movie already exists.");
            else
                movie = _mapper.Map<Movie>(Model);  // Convert ViewModel from CommandViewModel to Movie type
                movie.Director = _context.Directors.Where(i => i.DirectorId == movie.DirectorId).Single();
                movie.Genre = _context.Genres.Where(i => i.GenreId == movie.GenreId).Single();
                _context.Movies.Add(movie);
                _context.SaveChanges();
        }
    }
}