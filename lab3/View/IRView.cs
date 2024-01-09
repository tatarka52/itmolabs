using RLab3.Model;

namespace RLab3.View;

public interface IRView
{
    void ShowInfo();
    string CommandQuery();
    int EquationTypeQuery();
    int[] TypeOneParametersQuery();
    int[] TypeTwoParametersQuery();
    void PrintSolution(Equation equation);
    int IndexQuery();
    int MenuQuery();
}
