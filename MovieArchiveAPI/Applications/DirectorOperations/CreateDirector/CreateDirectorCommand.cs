using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.DirectorOperations.CreateDirector
{
    public class CreateDirectorCommand
    {
        public DirectorDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateDirectorCommand(MovieArchiveDBContext context, IMapper mapper, DirectorDTO model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // If there is no other director with the same name, it will be added and if there is, it will throw an error.
        public void Handle(){
            var director = _context.Directors.Where(i => i.Name == Model.Name).SingleOrDefault();
            if(director is not null)
                throw new InvalidOperationException("The director already exists.");
            else
                director = _mapper.Map<Director>(Model);  // Convert ViewModel from CommandViewModel to Director type
                _context.Directors.Add(director);
                _context.SaveChanges();
        }
    }
}