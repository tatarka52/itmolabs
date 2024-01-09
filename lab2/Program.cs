using RLab2.Controller;
using RLab2.Model;
using RLab2.View;

namespace RLab2;

public static class Program
{
    public static void Main(string[] args)
    {
        var equations = new List<Equation>();
        var rView = new RView();
        var rController = new RController(equations, rView);
        rController.Run();
    }
}
