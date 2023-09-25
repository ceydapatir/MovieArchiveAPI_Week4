using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.GenreOperations.GetGenreByName
{
    public class GetGenreByNameQuery
    {
        public string GenreName { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetGenreByNameQuery(MovieArchiveDBContext context, IMapper mapper, string genreName){
            _context = context;
            _mapper = mapper;
            GenreName = genreName;
        }

        // Data with GenreName is searched, if any it is returned, otherwise it throws an error.
        public GenreViewModel Handle(){
            var genre = _context.Genres.Where(i => i.Name.Contains(GenreName,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            GenreViewModel ViewModel = new GenreViewModel();
            if( genre is null)
                throw new InvalidOperationException("The genre doesn't exist.");
            else
                ViewModel = _mapper.Map<GenreViewModel>(genre); // Convert genre from Genre to QueryViewModel type
            
            return ViewModel;       
        }
    }
}