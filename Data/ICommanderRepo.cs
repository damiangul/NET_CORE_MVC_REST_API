using System.Collections.Generic;
using First_NET_Project.Models;

namespace First_NET_Project.Data
{
  public interface ICommanderRepo
  {
      IEnumerable<Command> GetAllCommands();
      Command GetCommandById(int id);
  }
}