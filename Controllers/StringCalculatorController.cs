using Microsoft.AspNetCore.Mvc;

namespace StringCalculator.Controllers
{
    [ApiController]
    public class StringCalculatorController : ControllerBase
    {
        private readonly ILogger<StringCalculatorController> logger;
        private readonly StringCalculator calculator;

        public StringCalculatorController(
            ILogger<StringCalculatorController> logger,
            StringCalculator calculator)
        {
            this.logger = logger;
            this.calculator = calculator;
        }

        [HttpPost("Add")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add([FromBody] Request request)
        {
            try
            {
                return Ok(calculator.Add(request.Numbers));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
