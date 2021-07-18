using AutoMapper;
using First_NET_Project.Dtos;
using First_NET_Project.Models;

namespace First_NET_Project.Profiles
{
  public class CommandsProfile : Profile
  {
    public CommandsProfile()
    {
        //Source -> Target PAMIETAJ
        CreateMap<Command, CommandReadDto>();
        //Tutaj wazne co do czego pamietaj!
        CreateMap<CommandCreateDto, Command>();
    }
  }
}