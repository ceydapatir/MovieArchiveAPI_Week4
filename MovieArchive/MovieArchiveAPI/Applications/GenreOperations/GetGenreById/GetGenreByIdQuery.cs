using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.GenreOperations.GetGenreById
{
    public class GetGenreByIdQuery
    {
        public int GenreId { get; set; }
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;
        public GetGenreByIdQuery(IMovieArchiveDBContext context, IMapper mapper, int genreId){
            _context = context;
            _mapper = mapper;
            GenreId = genreId;
        }

        // Data with GenreId is searched, if any it is returned, otherwise it throws an error.
        public GenreViewModel Handle(){
            var genre = _context.Genres.Where(i => i.GenreId == GenreId).SingleOrDefault();
            GenreViewModel ViewModel = new GenreViewModel();
            if( genre is null)
                throw new InvalidOperationException("The genre doesn't exist.");
            else
                ViewModel = _mapper.Map<GenreViewModel>(genre); // Convert genre from Genre to QueryViewModel type
            
            return ViewModel;       
        }
    }
}