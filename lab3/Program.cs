using RLab3.Controller;
using RLab3.Model;
using RLab3.Repository;
using RLab3.View;

namespace RLab3;

public static class Program
{
    public static void Main(string[] args)
    {
        var equations = new List<Equation>();
        var rView = new RView();
        var rRepository = new RRepository();
        var rController = new RController(equations, rView, rRepository);
        rController.Run();
    }
}
