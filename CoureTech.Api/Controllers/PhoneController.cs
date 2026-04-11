using Microsoft.AspNetCore.Mvc;
using CoureTech.Application.Interfaces;

namespace CoureTech.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IPhoneLookupService _phoneLookupService;

    public PhoneController(IPhoneLookupService phoneLookupService)
    {
        _phoneLookupService = phoneLookupService;
    }

    [HttpGet("{number}")]
    public async Task<IActionResult> Get(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
            return BadRequest(new { error = "Invalid phone number. Only digits are allowed." });

        var phone = number.StartsWith('+') ? number[1..] : number;

        if (!phone.All(char.IsDigit))
            return BadRequest(new { error = "Invalid phone number. Only digits are allowed." });

        var result = await _phoneLookupService.LookupAsync(phone);

        if (result is null)
            return NotFound(new { error = "Country code not found for the given phone number." });

        return Ok(result);
    }
}
