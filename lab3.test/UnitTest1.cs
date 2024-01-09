using Moq;
using RLab3.Controller;
using RLab3.Model;
using RLab3.Repository;
using RLab3.View;

namespace RLab3.Test;

public class UnitTest1
{
    [Theory]
    [InlineData(-2,4,2)]
    [InlineData(8,16,-2)]
    public void SolveTypeOneEquationTest(int k, int b, double expected)
    {
        var mock = new Mock<IRRepository>();
        mock.Setup(c => c.DBLoad()).Returns([]);
        mock.Setup(c => c.JSONLoad()).Returns([]);
        var equations = new List<Equation>();
        var rView = new RView();
        var rController = new RController(equations, rView, mock.Object);
        var actual = rController.SolveTypeOneEquation(k, b);
        Assert.Equal(actual, expected); 
    }
    
    [Fact]
    public void FindEquationTest()
    {
        var mock = new Mock<IRRepository>();
        mock.Setup(c => c.DBLoad()).Returns([]);
        mock.Setup(c => c.JSONLoad()).Returns([]);
        var equations = new List<Equation>();
        var expected = new Equation { Id = 1, Condition = "condition", Solution = "2.3" };
        equations.Add(expected);
        equations.Add(new Equation{Id = 2, Condition = "noifeafa", Solution = "78"});

        var rView = new RView();
        var rController = new RController(equations, rView, mock.Object);
        var actual = rController.FindEquation(1);
        
        Assert.Equal(expected, actual);
    }
}
