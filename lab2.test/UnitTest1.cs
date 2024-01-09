using RLab2.Controller;
using RLab2.Model;
using RLab2.View;

namespace RLab2.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(-2,4,2)]
    [InlineData(8,16,-2)]
    public void SolveTypeOneEquationTest(int k, int b, double expected)
    {
        var equations = new List<Equation>();
        var rView = new RView();
        var rController = new RController(equations, rView);
        var actual = rController.SolveTypeOneEquation(k, b);
        Assert.Equal(actual, expected); 
    }
    
    [Fact]
    public void FindEquationTest()
    {
        var equations = new List<Equation>();
        var expected = new Equation { Id = 1, Condition = "condition", Solution = "2.3" };
        equations.Add(expected);
        equations.Add(new Equation{Id = 2, Condition = "noifeafa", Solution = "78"});

        var rView = new RView();
        var rController = new RController(equations, rView);
        var actual = rController.FindEquation(1);
        
        Assert.Equal(expected, actual);
    }
}
