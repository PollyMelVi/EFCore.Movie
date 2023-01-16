using AutoMapper;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles;

public class ActorDtoProfile:Profile
{
    public ActorDtoProfile()
    {
        CreateMap<Actor, ActorDto>().ReverseMap();
        CreateMap<ActorDto, ActorViewModel>();
        CreateMap<ActorDto, EditActorViewModel>().ReverseMap();
        CreateMap<ActorDto, DeleteActorViewModel>().ReverseMap();
        CreateMap<ActorDto, InputActorViewModel>().ReverseMap();
    }
}