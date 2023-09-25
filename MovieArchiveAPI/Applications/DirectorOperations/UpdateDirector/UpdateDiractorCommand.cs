using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.DirectorOperations.UpdateDirector
{
    public class UpdateDiractorCommand
    {
        public int DirectorId { get; set; }
        public DirectorDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public UpdateDiractorCommand(MovieArchiveDBContext context, IMapper mapper, int directorId, DirectorDTO model)
        {
            _context = context;
            _mapper = mapper;
            DirectorId = directorId;
            Model = model;
        }

        // Data with DirectorId is searched, if any it is replaced with a new one, otherwise it throws an error.
        public void Handle(){
            var director = _context.Directors.Where(i => i.Name.Contains(Model.Name,StringComparison.OrdinalIgnoreCase) && i.Surname.Contains(Model.Surname,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if(director is not null) // Throw an error if the new name already exists in the system
                throw new InvalidOperationException("The director already exist.");
            else
                director = _context.Directors.Where(i => i.DirectorId == DirectorId).FirstOrDefault();
                if(director is null)
                    throw new InvalidOperationException("The director doesn't exist.");
                else
                    director = _mapper.Map(Model,director);  // Reverse director with ViewModel
                    _context.SaveChanges();
        }
    }
}