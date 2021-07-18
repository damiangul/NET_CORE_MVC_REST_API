using System;
using System.Collections.Generic;
using System.Linq;
using First_NET_Project.Models;

namespace First_NET_Project.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
        _context = context;
    }

    public void CreateCommand(Command cmd)
    {
      if(cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Add(cmd);
    }

    public void DeleteCommand(Command cmd)
    {
      if(cmd == null)
      {
        throw new ArgumentNullException(nameof(cmd));
      }

      _context.Commands.Remove(cmd);
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
      //Gdy robimy creaty, delete czy update to musi być wywolana poniższa komenda aby zmiany zostały zapisane.
      return (_context.SaveChanges() >= 0);
    }

    public void UpdateCommand(Command cmd)
    {
      //Nic nie dajesz. Nie musisz implementować.
    }
  }
}