using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.User.Services;
using SolarLab.Academy.Contracts.User;
using System.Net;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Пользователи.
/// </summary>
[ApiController]
[Route("user")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    /// <summary>
    /// Получение списка всех зарегистрированных пользоваателей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список моделей передачи данных зарегистрированных пользователей.</returns>
    [HttpGet("all")]
    [ProducesResponseType(typeof(IReadOnlyCollection<UserDto>), (int)HttpStatusCode.OK)] // возврат статус кода 200
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)] // возврат статус кода 500
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        
        return Ok(users);
    }
}
