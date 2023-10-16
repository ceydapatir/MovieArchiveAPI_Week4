using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Context;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.ViewModel;

namespace MovieArchiveAPI.Applications.DirectorOperations.GetDirector
{
    public class GetDirectorQuery
    {
        private readonly IMapper _mapper;
        private readonly IMovieArchiveDBContext _context;
        public GetDirectorQuery(IMovieArchiveDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // Get all directors, if there is no genre, throw an error
        public List<DirectorViewModel> Handle(){
            var DirectorList = _context.Directors.OrderBy(i => i.DirectorId).ToList<Director>();
            List<DirectorViewModel> ViewModelList = new List<DirectorViewModel>();
            DirectorViewModel ViewModel = new DirectorViewModel();
            if(DirectorList.Count() == 0)
                throw new InvalidOperationException("There are no directors.");
            else
                foreach (var director in DirectorList)
                {
                    ViewModel = _mapper.Map<DirectorViewModel>(director); // Convert director from Director to QueryViewModel type
                    ViewModelList.Add(ViewModel);
                }
            return ViewModelList;       
        }
    }
}