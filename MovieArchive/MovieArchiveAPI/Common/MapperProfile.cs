using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MovieArchiveAPI.Data.Entities;
using MovieArchiveAPI.Models.ViewModel;
using MovieArchiveAPI.Models.DTO;

namespace MovieArchiveAPI.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile(){
            CreateMap<Movie, MovieViewModel>() // map to get
                .ForMember(i => i.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(i => i.Director, opt => opt.MapFrom(src => src.Director.Name + " " + src.Director.Surname))
                .ForMember(i => i.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd/MM/yyy")));
            CreateMap<MovieDTO, Movie>(); // map to create
            CreateMap<MovieDTO, Movie>().ReverseMap(); // map to update
            CreateMap<Movie, MovieDTO>(); // map to create
            
            CreateMap<Genre, GenreViewModel>(); // map to get
            CreateMap<GenreDTO, Genre>(); // map to create
            CreateMap<GenreDTO, Genre>().ReverseMap(); // map to update
            
            CreateMap<Director, DirectorViewModel>() // map to get
                .ForMember(i => i.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Date.ToString("dd/MM/yyy")));
            CreateMap<DirectorDTO, Director>(); // map to create
            CreateMap<DirectorDTO, Director>().ReverseMap(); // map to update
        }
    }
}