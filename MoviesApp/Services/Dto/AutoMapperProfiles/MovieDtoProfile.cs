using AutoMapper;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class MovieDtoProfile:Profile
    {
        public MovieDtoProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<MovieDto, MovieViewModel>();
            CreateMap<MovieDto, EditMovieViewModel>().ReverseMap();
            CreateMap<MovieDto, DeleteMovieViewModel>().ReverseMap();
            CreateMap<MovieDto, InputMovieViewModel>().ReverseMap();
        }
    }
}