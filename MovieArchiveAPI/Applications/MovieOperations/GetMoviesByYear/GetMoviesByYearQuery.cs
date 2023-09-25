using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace MovieArchiveAPI.Applications.MovieOperations.GetMoviesByYear
{
    public class GetMoviesByYearQuery
    {
        public int MovieYear { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetMoviesByYearQuery(MovieArchiveDBContext context, IMapper mapper, int movieYear){
            _context = context;
            _mapper = mapper;
            MovieYear = movieYear;
        }

        // Data with MovieYear is searched, if any it is returned, otherwise it throws an error.
        public List<MovieViewModel> Handle(){
            var MovieList = _context.Movies.Include(i => i.Genre).Include(i => i.Director).Where(i => i.PublishDate.Year == MovieYear).ToList();
            List<MovieViewModel> ViewModelList = new List<MovieViewModel>();
            MovieViewModel ViewModel = new MovieViewModel();
            if(MovieList.Count() == 0)
                throw new InvalidOperationException("No movie found for this year.");
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