using Microsoft.EntityFrameworkCore;
using RLab4.Model;

namespace RLab4.DB;

public class RContext:DbContext
{
    public DbSet<Equation>? Equations { get; set; }
    
    public RContext(DbContextOptions<RContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
