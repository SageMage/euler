using euler.Models;
using euler.Services;
using Microsoft.AspNetCore.Mvc;

namespace euler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Problem1Controller : ControllerBase
    { 
       public ILogger<Problem1Controller> Logger { get; }
       private readonly IProblem1Service _problem1Service;

       public Problem1Controller(ILogger<Problem1Controller> logger, IProblem1Service problem1Service)
       {
           Logger = logger;
           _problem1Service = problem1Service;
       }

        [HttpGet(Name = "GetProblem1")]
        public IEnumerable<Problem1Model> Get()
        {
            // call into _problem1Service to get the calculated sum and return it.
            return new List<Problem1Model>
            {
                new()
                {
                    Limit = 10,
                    Sum = _problem1Service.CalculateSumOfMultiples(10)
                },
                new()
                {
                    Limit = 1000,
                    Sum = _problem1Service.CalculateSumOfMultiples(1000)
                }
            };
        }
    }
}