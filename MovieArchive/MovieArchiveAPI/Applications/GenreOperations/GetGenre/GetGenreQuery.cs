using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.GenreOperations.GetGenre
{
    public class GetGenreQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;
        public GetGenreQuery(IMovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // Get all genres, if there is no genre, throw an error
        public List<GenreViewModel> Handle(){
            var GenreList = _context.Genres.OrderBy(i => i.GenreId).ToList<Genre>();
            List<GenreViewModel> ViewModelList = new List<GenreViewModel>();
            GenreViewModel ViewModel = new GenreViewModel();
            if(GenreList.Count() == 0)
                throw new InvalidOperationException("There are no genres.");
            else
                foreach (var movie in GenreList)
                {
                    ViewModel = _mapper.Map<GenreViewModel>(movie); // Convert genre from Genre to QueryViewModel type
                    ViewModelList.Add(ViewModel);
                }
            return ViewModelList;       
        }
    }
}