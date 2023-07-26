using euler.Models;
using euler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace euler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Problem3Controller : ControllerBase
    { 
        public ILogger<Problem3Controller> Logger { get; }
        private readonly IProblem3Service _problem3Service;

        public Problem3Controller(ILogger<Problem3Controller> logger, IProblem3Service problem3Service)
        {
            Logger = logger;
            _problem3Service = problem3Service;
        }

        [HttpGet(Name = "GetProblem3")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Problem3Model> Get()
        {
            try
            {
                var limit = 600851475143;
                var largestPrimeFactor = _problem3Service.CalculateLargestPrimeFactor(limit);

                return Ok(new Problem3Model
                {
                    Limit = limit,
                    LargestPrimeFactor = largestPrimeFactor
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while calculating largest prime factor.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
