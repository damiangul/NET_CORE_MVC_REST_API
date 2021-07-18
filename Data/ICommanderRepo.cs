using System.Collections.Generic;
using First_NET_Project.Models;

namespace First_NET_Project.Data
{
  public interface ICommanderRepo
  {
      bool SaveChanges();
      IEnumerable<Command> GetAllCommands();
      Command GetCommandById(int id);
      void CreateCommand(Command cmd);
  }
}