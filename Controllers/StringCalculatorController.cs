using Microsoft.AspNetCore.Mvc;

namespace StringCalculator.Controllers
{
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {
        private readonly ILogger<StringCalculatorController> _logger;

        public StringCalculatorController(ILogger<StringCalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] Request request)
        {
            try
            {
                return Ok(new StringCalculator().Add(request.Numbers));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
