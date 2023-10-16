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
        private readonly IMovieArchiveDBContext _context;

        public UpdateGenreCommand(IMovieArchiveDBContext context, IMapper mapper, GenreDTO model)
        {
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // Data with GenreId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle( int genreId){
            GenreId = genreId;
            var genre = _context.Genres.Where(i => i.GenreId == GenreId).SingleOrDefault();
            if(genre is null)
                throw new InvalidOperationException("The genre doesn't exist.");
            else
                genre = _mapper.Map(Model,genre);  // Reverse movie with ViewModel
                _context.SaveChanges();
        }
    }
}