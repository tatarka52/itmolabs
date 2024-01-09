using RLab2.Model;
using RLab2.View;

namespace RLab2.Controller;

public class RController
{
    private readonly List<Equation> _equations;

    private readonly IRView _irView;

    public RController(List<Equation> equations, IRView irView)
    {
        _equations = equations;
        _irView = irView;
    }

    public double SolveTypeOneEquation(int k, int b)
    {
        return double.Round( (double)-b / k, 2);
    }

    public Equation FindEquation(int index)
    {
        return _equations[index-1];
    }

    private double[] SolveTypeTwoEquation(int a, int b, int c)
    {
        var xes = new double[2];
        var d = (b ^ 2) - 4 * a * c;
        xes[0] = double.Round((-b + Math.Sqrt(d)) / (2 * a), 2);
        xes[1] = double.Round((-b - Math.Sqrt(d)) / (2 * a), 2);

        return xes;
    }

    public void Run()
    {
        _irView.ShowInfo();
        var running = true;
        while (true)
        {
            var menu = _irView.CommandQuery();
            switch (menu)
            {
                case "solve":
                    switch (_irView.EquationTypeQuery())
                    {
                        case 1:
                            var p = _irView.TypeOneParametersQuery();
                            var x = SolveTypeOneEquation(p[0], p[1]);
                            var equation = new Equation
                            {
                                Id = _equations.Count + 1,
                                Condition = $"{p[0]} * x + {p[1]} = 0",
                                Solution = x.ToString()
                            };
                            _equations.Add(equation);

                            _irView.PrintSolution(equation);
                            break;
                        case 2:
                            p = _irView.TypeTwoParametersQuery();
                            var x2 = SolveTypeTwoEquation(p[0], p[1], p[2]);
                            equation = new Equation
                            {
                                Id = _equations.Count,
                                Condition = $"{p[0]} * x^2 + {p[1]} * b + {p[2]} = 0",
                                Solution = x2[0] + ", " + x2[1]
                            };
                            _equations.Add(equation);

                            _irView.PrintSolution(equation);
                            break;
                    }

                    break;
                case "find":
                    _irView.PrintSolution(FindEquation(_irView.IndexQuery()));
                    break;
                case "quit":
                    running = !running;
                    break;
            }

            if (!running)
                break;
        }
    }
}
