using RLab3.Model;

namespace RLab3.Repository;

public interface IRRepository
{
    void DBSave(List<Equation> equations);
    List<Equation> DBLoad();
    void JSONSave(List<Equation> equations);
    List<Equation> JSONLoad();
}
