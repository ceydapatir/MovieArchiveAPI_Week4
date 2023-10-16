using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public int DirectorId { get; set; }
        public DirectorDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;

        public UpdateDirectorCommand(IMovieArchiveDBContext context, IMapper mapper,  DirectorDTO model)
        {
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // Data with DirectorId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(int directorId){
            DirectorId = directorId;
            var director = _context.Directors.Where(i => i.DirectorId == DirectorId).SingleOrDefault();
            if(director is null)
                throw new InvalidOperationException("The director doesn't exist.");
            else
                director = _mapper.Map(Model,director);  // Reverse director with ViewModel
                _context.SaveChanges();
        }
    }
}