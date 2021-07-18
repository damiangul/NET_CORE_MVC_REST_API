using System.Collections.Generic;
using First_NET_Project.Data;
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

    public CommandsController(ICommanderRepo repository)
    {
      _repository = repository;
    }

    //  Pomysł był taki ze to na dole jest mniej uniwersalne dla tego kontruktora. Teraz gdy zmienimy
    //  repo w pliku startup.cs to wszystko i tak będzie elegancko działać a to na dole działa tylko dla MockCommanderRepo.
    //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
    
    [HttpGet]
    public ActionResult <IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repository.GetAllCommands();
      
      return Ok(commandItems);
    }

    //GET api/commands/{id} etc...
    [HttpGet("{id}")]
    public ActionResult <Command> GetCommandById(int id)
    {
      var commandItem = _repository.GetCommandById(id);

      return Ok(commandItem);
    }
  }
}