using Microsoft.EntityFrameworkCore;
using RLab3.Model;

namespace RLab3.DB;

public class RContext:DbContext
{
    public DbSet<Equation>? Equations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Equations.db");
    }
}
