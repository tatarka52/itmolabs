using Microsoft.EntityFrameworkCore;
using RLab4.DB;
using RLab4.Model;

namespace RLab4.Repository;

public class RRepository : IRRepository
{
    private readonly RContext _context;

    public RRepository(RContext context)
    {
        _context = context;
    }


    public Task<Equation> SolveTypeOneEquation(int k, int b)
    {
        var equation = new Equation
        {
            Id = _context.Equations.Count() + 1,
            Condition = $"{k} * x + {b} = 0",
            Solution = double.Round((double)-b / k, 2).ToString()
        };
        _context.Equations.Add(equation);
        _context.SaveChangesAsync();
        return Task.FromResult(equation);
    }

    public Task<Equation> SolveTypeTwoEquation(int a, int b, int c)
    {
        var xes = new double[2];
        var d = (b ^ 2) - 4 * a * c;
        xes[0] = double.Round((-b + Math.Sqrt(d)) / (2 * a), 2);
        xes[1] = double.Round((-b - Math.Sqrt(d)) / (2 * a), 2);
        var equation = new Equation
        {
            Id = _context.Equations.Count() + 1,
            Condition = $"{a} * x^2 + {b} * x + {c} = 0",
            Solution = xes[0] + ", " + xes[1]
        };
        _context.Equations.Add(equation);
        _context.SaveChangesAsync();
        return Task.FromResult(equation);
    }

    public Task<List<Equation>> Find(int index)
    {
        if (_context.Equations.Count() < index || index < 1)
            throw new Exception("Wrong index.");
        return _context.Equations.Where(i => i.Id == index).ToListAsync();
    }
}
