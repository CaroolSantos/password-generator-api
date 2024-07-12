using Microsoft.AspNetCore.Mvc;
using PasswordGeneratorAPI.Models;
using PasswordGeneratorAPI.Services;
using System.Threading.Tasks;

namespace PasswordGeneratorAPI.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class PasswordController : ControllerBase
{
    private readonly PasswordService _passwordService;

    public PasswordController(PasswordService passwordService)
    {
        _passwordService = passwordService;
    }

    [HttpPost("generate")]
    public async Task<ActionResult<Password>> GeneratePassword([FromQuery] int length, [FromQuery] bool includeLowerCase, [FromQuery] bool includeUpperCase, [FromQuery] bool includeNumbers, [FromQuery] bool includeSpecialCharacters)
    {
        var password = await _passwordService.GeneratePasswordAsync(length, includeUpperCase, includeLowerCase, includeNumbers, includeSpecialCharacters);
        return Ok(password);
    }
}
}