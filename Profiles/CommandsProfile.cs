using AutoMapper;
using First_NET_Project.Dtos;
using First_NET_Project.Models;

namespace First_NET_Project.Profiles
{
  public class CommandsProfile : Profile
  {
    public CommandsProfile()
    {
        CreateMap<Command, CommandReadDto>();
    }
  }
}