using System.Collections.Generic;
using RLab5.Models;

namespace RLab5.Repository;

public interface IRRepository
{
    void SaveToDb(IEnumerable<ContactDto> wordModels);
    List<ContactDto> LoadFromDb();
}
