using Microsoft.AspNetCore.Mvc;
using RLab4.Model;
using RLab4.Repository;

namespace RLab4.Controller;

[ApiController]
public class RController : ControllerBase
{
    private readonly IRRepository _rRepository;

    public RController(IRRepository rRepository)
    {
        _rRepository = rRepository;
    }

    [HttpPost]
    [Route("/solve-typeoneequation")]
    public Task<Equation> SolveTypeOneEquation([FromBody] string fake, int k, int b)
    {
        return _rRepository.SolveTypeOneEquation(k, b);
    }
    
    [HttpPost]
    [Route("/solve-typetwoequation")]
    public Task<Equation> SolveTypeTwoEquation([FromBody] string fake, int a, int b, int c)
    {
        return _rRepository.SolveTypeTwoEquation(a,b,c);
    }

    [HttpGet]
    [Route("/find")]
    public Task<List<Equation>> Find(int index)
    {
        return _rRepository.Find(index);
    }
}
