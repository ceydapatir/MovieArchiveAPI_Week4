using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMovie
{
    public class GetMoviesQuery
    {
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetMoviesQuery(MovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // Get all movies, if there is no movie, throw an error
        public List<MovieViewModel> Handle(){
            var MovieList = _context.Movies.Include(i => i.Genre).Include(i => i.Director).OrderBy(i => i.MovieId).ToList<Movie>();
            List<MovieViewModel> ViewModelList = new List<MovieViewModel>();
            MovieViewModel ViewModel = new MovieViewModel();
            if(MovieList.Count() == 0)
                throw new InvalidOperationException("There are no movies.");
            else
                foreach (var movie in MovieList)
                {
                    ViewModel = _mapper.Map<MovieViewModel>(movie); // Convert movie from Movie to QueryViewModel type
                    ViewModelList.Add(ViewModel);
                }
            return ViewModelList;       
        }
    }
}