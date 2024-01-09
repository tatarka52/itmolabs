using RLab2.Model;

namespace RLab2.View;

public interface IRView
{
    void ShowInfo();
    string CommandQuery();
    int EquationTypeQuery();
    int[] TypeOneParametersQuery();
    int[] TypeTwoParametersQuery();
    void PrintSolution(Equation equation);
    int IndexQuery();
}
