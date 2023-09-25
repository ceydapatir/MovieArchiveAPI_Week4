using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Applications.GenreOperations.CreateGenre
{
    public class CreateGenreCommand
    {
        public GenreDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;

        public CreateGenreCommand(MovieArchiveDBContext context, IMapper mapper, GenreDTO model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // If there is no other genre with the same name, it will be added and if there is, it will throw an error.
        public void Handle(){
            var genre = _context.Genres.Where(i => i.Name == Model.Name).SingleOrDefault();
            if(genre is not null)
                throw new InvalidOperationException("The genre already exists.");
            else
                genre = _mapper.Map<Genre>(Model);  // Convert ViewModel from CommandViewModel to Genre type
                _context.Genres.Add(genre);
                _context.SaveChanges();
        }
    }
}