using euler.Models;
using euler.Services;
using Microsoft.AspNetCore.Mvc;

namespace euler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Problem2Controller : ControllerBase
    {
        private readonly IProblem2Service _problem2Service;
        public ILogger<Problem2Controller> Logger { get; set; }

        public Problem2Controller(ILogger<Problem2Controller> logger, IProblem2Service problem2Service)
        {
            Logger = logger;
            _problem2Service = problem2Service;
        }

        [HttpGet(Name = "GetProblem2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Problem2Model> Get()
        {
            try
            {
                var limit = 4000000;
                var sum = _problem2Service.CalculateSumOfEvenFibonacciNumbers(limit);

                return Ok(new Problem2Model
                {
                    Limit = limit,
                    Sum = sum
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while calculating sum of even Fibonacci numbers.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
