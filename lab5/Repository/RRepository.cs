using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RLab5.Database;
using RLab5.Models;

namespace RLab5.Repository;

public class RRepository:IRRepository
{
    private readonly RContext _context;
    
    public RRepository(RContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }
    public void SaveToDb(IEnumerable<ContactDto> contacts)
    {
        _context.Contacts?.RemoveRange(_context.Contacts);
        _context.SaveChanges();

        // Добавление новых задач и сохранение изменений
        _context.Contacts?.AddRange(contacts);
        _context.SaveChanges();
    }

    public List<ContactDto> LoadFromDb()
    {
        return _context.Contacts!.ToList();
    }
}
