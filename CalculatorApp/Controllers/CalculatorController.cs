using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add([FromQuery] double num1, [FromQuery] double num2)
        {
            return Ok(new { Result = num1 + num2 });
        }

        [HttpGet("subtract")]
        public IActionResult Subtract([FromQuery] double num1, [FromQuery] double num2)
        {
            return Ok(new { Result = num1 - num2 });
        }

        [HttpGet("multiply")]
        public IActionResult Multiply([FromQuery] double num1, [FromQuery] double num2)
        {
            return Ok(new { Result = num1 * num2 });
        }

        [HttpGet("divide")]
        public IActionResult Divide([FromQuery] double num1, [FromQuery] double num2)
        {
            if (num2 == 0) return BadRequest("Division by zero is not allowed.");
            return Ok(new { Result = num1 / num2 });
        }
    }
}
