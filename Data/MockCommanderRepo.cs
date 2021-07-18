using System.Collections.Generic;
using First_NET_Project.Models;

namespace First_NET_Project.Data
{
  //FOR TESTING
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      var commands = new List<Command>
      {
        new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and Pan"},
        new Command{Id=1, HowTo="Cut a bread", Line="Get a knife", Platform="Knife and chopping board"},
        new Command{Id=2, HowTo="XDDD", Line="XDD", Platform="XD"}
      };

      return commands;
    }

    public Command GetCommandById(int id)
    {
      return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and Pan"};
    }

    public bool SaveChanges()
    {
      throw new System.NotImplementedException();
    }
  }
}