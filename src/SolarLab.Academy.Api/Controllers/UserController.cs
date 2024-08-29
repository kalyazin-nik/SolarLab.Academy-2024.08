using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.User.Services;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.Api.Controllers;

[ApiController]
[Route("controller")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var user = await _userService.Register(model, cancellationToken);

        return Ok(user);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
