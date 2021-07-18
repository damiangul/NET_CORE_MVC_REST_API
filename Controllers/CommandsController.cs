using System.Collections.Generic;
using AutoMapper;
using First_NET_Project.Data;
using First_NET_Project.Dtos;
using First_NET_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_NET_Project.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase //Base jest bez wsparcia dla widoków. Zwykłe "Controller" jest ze wsparciem dla widoków.
  {
    //Dependency Injection - tak to sie nazywa co zrobilismy z tym repo 
    private readonly ICommanderRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    //  Pomysł był taki ze to na dole jest mniej uniwersalne dla tego kontruktora. Teraz gdy zmienimy
    //  repo w pliku startup.cs to wszystko i tak będzie elegancko działać a to na dole działa tylko dla MockCommanderRepo.
    //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    
    [HttpGet]
    public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
    }

    //GET api/commands/{id} etc...
    [HttpGet("{id}", Name = "GetCommandById")]
    public ActionResult <CommandReadDto> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);

      if(commandItem != null)
      {
        return Ok(_mapper.Map<CommandReadDto>(commandItem));
      }

      return NotFound();
    }

    //POST api/commands
    [HttpPost]
    public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto) 
    {
      var commandModel = _mapper.Map<Command>(commandCreateDto);
      _repository.CreateCommand(commandModel);
      _repository.SaveChanges();

      //Dodalismy zmienna typu Command do bazy a dla uzytkownika wyswietlamy model CommandReadDto.
      var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

      return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
    }
  }
}