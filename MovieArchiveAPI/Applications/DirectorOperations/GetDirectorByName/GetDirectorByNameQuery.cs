using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.DTO;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.DirectorOperations.GetDirectorByName
{
    public class GetDirectorByNameQuery
    {
        public GetDirectorByNameDTO Model { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetDirectorByNameQuery(MovieArchiveDBContext context, IMapper mapper, GetDirectorByNameDTO model){
            _context = context;
            _mapper = mapper;
            Model = model;
        }

        // Data with name and surname is searched, if any it is returned, otherwise it throws an error.
        public DirectorViewModel Handle(){
            var director = _context.Directors.Where(i => i.Name.Contains(Model.Name,StringComparison.OrdinalIgnoreCase) && i.Surname.Contains(Model.Surname,StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            DirectorViewModel ViewModel = new DirectorViewModel();
            if( director is null)
                throw new InvalidOperationException("The director doesn't exist.");
            else
                ViewModel = _mapper.Map<DirectorViewModel>(director); // Convert director from Director to QueryViewModel type
            
            return ViewModel;       
        }
    }
}