using First_NET_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace First_NET_Project.Data 
{
  public class CommanderContext : DbContext
  {
    public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
    {
        
    }

    public DbSet<Command> Commands { get; set; }
  }
}