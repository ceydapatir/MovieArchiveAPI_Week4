using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.DirectorOperations.GetDirectorById
{
    public class GetDirectorByIdQuery
    {
        public int DirectorId { get; set; }
        private readonly IMapper _mapper;
        private readonly MovieArchiveDBContext _context;
        public GetDirectorByIdQuery(MovieArchiveDBContext context, IMapper mapper, int directorId){
            _context = context;
            _mapper = mapper;
            DirectorId = directorId;
        }

        // Data with DirectorId is searched, if any it is returned, otherwise it throws an error.
        public DirectorViewModel Handle(){
            var director = _context.Directors.Where(i => i.DirectorId == DirectorId).SingleOrDefault();
            DirectorViewModel ViewModel = new DirectorViewModel();
            if( director is null)
                throw new InvalidOperationException("The director doesn't exist.");
            else
                ViewModel = _mapper.Map<DirectorViewModel>(director); // Convert director from Director to QueryViewModel type
            
            return ViewModel;       
        }
    }
}