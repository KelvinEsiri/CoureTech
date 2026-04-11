using Microsoft.AspNetCore.Mvc;
using CoureTech.Application.Interfaces;

namespace CoureTech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly IScoreCalculatorService _calculator;

    public ScoreController(IScoreCalculatorService calculator)
    {
        _calculator = calculator;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return BadRequest(new { error = "Please provide a 'numbers' query parameter." });

        var parts = numbers.Split(',');
        var parsed = new List<int>();

        foreach (var part in parts)
        {
            if (!int.TryParse(part.Trim(), out int value))
                return BadRequest(new { error = $"'{part.Trim()}' is not a valid integer." });

            parsed.Add(value);
        }

        return Ok(new { score = _calculator.Calculate(parsed) });
    }
}
