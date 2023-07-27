using euler.Models;
using euler.Services;
using Microsoft.AspNetCore.Mvc;

namespace euler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Problem4Controller : ControllerBase
    {
        public ILogger<Problem4Controller> Logger { get; }
        private readonly IProblem4Service _problem4Service;

        public Problem4Controller(ILogger<Problem4Controller> logger, IProblem4Service problem4Service)
        {
            Logger = logger;
            _problem4Service = problem4Service;
        }

        [HttpGet(Name = "GetProblem4")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Problem4Model> Get()
        {
            try
            {
                var number = 3;
                var largestPalindromeProduct = _problem4Service.CalculateLargestPalindromeProduct(number);

                return Ok(new Problem4Model
                {
                    Number = number,
                    LargestPalindromeProduct = largestPalindromeProduct
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occurred while calculating largest palindrome product.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
