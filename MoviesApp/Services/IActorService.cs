using System.Collections.Generic;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services;

public interface IActorService
{
    ActorDto GetActor(int id);
    IEnumerable<ActorDto> GetAllActors();
    ActorDto UpdateActor(int id, ActorDto actorDto);
    ActorDto AddActor(ActorDto actorDto);
    ActorDto DeleteActor(int id);
}