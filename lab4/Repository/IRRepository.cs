using RLab4.Model;

namespace RLab4.Repository;

public interface IRRepository
{
    Task<Equation> SolveTypeOneEquation(int k, int b);
    Task<Equation> SolveTypeTwoEquation(int a, int b, int c);
    Task<List<Equation>> Find(int index);
}
