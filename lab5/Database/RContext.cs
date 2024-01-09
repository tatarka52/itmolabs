using RLab5.Models;
using Microsoft.EntityFrameworkCore;

namespace RLab5.Database;

public class RContext : DbContext
{
    public DbSet<ContactDto>? Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Contacts.db");
    }
}
