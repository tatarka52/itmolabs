using RLab3.Model;

namespace RLab3.View;

public class RView : IRView
{
    public void ShowInfo()
    {
        Console.WriteLine(
            "Usage:\nUse on of commands:\n\"solve\" to select type of an equation and solve it\n\"find\" to get existing solution from memory\n\"quit\" to exit");
    }

    public int MenuQuery()
    {
        Console.WriteLine("Select a method to save and load data:\n1 - Database\n2 - JSON");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 2)
            throw new Exception("Wrong input.");
        return n;
    }

    public string CommandQuery()
    {
        Console.WriteLine("----\nInput the command:");
        var input = Console.ReadLine() ?? "";
        if (input != "solve" && input != "find" && input != "quit")
            throw new Exception("Invalid command. Please, retry.");
        return input;
    }

    public int EquationTypeQuery()
    {
        Console.WriteLine("Select the type of equation:\n1 - k * x + b = 0\n2 - a * x^2 + b * x + c = 0");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid || n < 1 || n > 2)
            throw new Exception("Wrong input.");
        return n;
    }

    public int[] TypeOneParametersQuery()
    {
        var parameters = new int[2];
        Console.Write("Input the factors:\nFactor 'k':");
        var isValid = int.TryParse(Console.ReadLine(), out var k);
        if (!isValid)
            throw new Exception("Wrong input.");
        parameters[0] = k;

        Console.Write("Free memeber 'b':");
        isValid = int.TryParse(Console.ReadLine(), out var b);
        if (!isValid)
            throw new Exception("Wrong input.");
        parameters[1] = b;
        return parameters;
    }

    public int[] TypeTwoParametersQuery()
    {
        var parameters = new int[3];
        Console.Write("Input the factors:\nFactor 'a':");
        var isValid = int.TryParse(Console.ReadLine(), out var a);
        if (!isValid)
            throw new Exception("Wrong input.");
        parameters[0] = a;

        Console.Write("Factor 'b':");
        isValid = int.TryParse(Console.ReadLine(), out var b);
        if (!isValid)
            throw new Exception("Wrong input.");
        parameters[1] = b;

        Console.Write("Factor 'c':");
        isValid = int.TryParse(Console.ReadLine(), out var c);
        if (!isValid)
            throw new Exception("Wrong input.");
        parameters[2] = c;
        return parameters;
    }

    public void PrintSolution(Equation equation)
    {
        Console.WriteLine($"{equation.Id}: {equation.Condition}, x = {equation.Solution}");
    }

    public int IndexQuery()
    {
        Console.WriteLine("Input the index:");
        var isValid = int.TryParse(Console.ReadLine(), out var n);
        if (!isValid)
            throw new Exception("Wrong input.");
        return n;
    }
}
