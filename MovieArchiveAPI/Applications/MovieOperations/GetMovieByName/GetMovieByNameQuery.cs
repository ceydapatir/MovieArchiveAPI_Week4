using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMovieByName
{
    public class GetMovieByNameQuery
    {
        public string MovieName { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetMovieByNameQuery(MovieArchiveDBContext context, IMapper mapper, string movieName){
            _context = context;
            _mapper = mapper;
            MovieName = movieName;
        }

        // Data with MovieName is searched, if any it is returned, otherwise it throws an error.
        public MovieViewModel Handle(){
            var movie = _context.Movies.Include(i => i.Genre).Include(i => i.Director).Where(i => i.Name.Contains(MovieName,StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            MovieViewModel ViewModel = new MovieViewModel();
            if( movie is null)
                throw new InvalidOperationException("The movie doesn't exist.");
            else
                ViewModel = _mapper.Map<MovieViewModel>(movie); // Convert movie from Movie to QueryViewModel type
            
            return ViewModel;       
        }
    }
}