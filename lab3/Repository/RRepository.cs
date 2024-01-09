using Newtonsoft.Json;
using RLab3.DB;
using RLab3.Model;

namespace RLab3.Repository;

public class RRepository : IRRepository
{
    private readonly string _jsonFilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "equations.json");

    private readonly RContext _context = new();

    public RRepository()
    {
        _context.Database.EnsureCreated();
    }

    public void DBSave(List<Equation> equations)
    {
        _context.Equations?.RemoveRange(_context.Equations);
        _context.SaveChanges();
        _context.Equations?.AddRange(equations);
        _context.SaveChanges();
    }

    public List<Equation> DBLoad()
    {
        return _context.Equations!.ToList();
    }

    public void JSONSave(List<Equation> equations)
    {
        var data = JsonConvert.SerializeObject(equations, Formatting.Indented);
        File.WriteAllText(_jsonFilePath, data);
    }

    public List<Equation> JSONLoad()
    {
        File.Create(_jsonFilePath).Close();

        var jsonData = File.ReadAllText(_jsonFilePath);
        var data = JsonConvert.DeserializeObject<List<Equation>>(jsonData) ?? [];

        return data.Select(equation => new Equation
            { Id = equation.Id, Condition = equation.Condition, Solution = equation.Solution }).ToList();
    }
}
