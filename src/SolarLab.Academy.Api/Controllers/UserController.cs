using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.User.Services;
using SolarLab.Academy.Contracts.User;
using System.Net;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Пользователи.
/// </summary>
[ApiController]
[Route("users")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(cancellationToken);
        
        return Ok(users);
    }

    /// <summary>
    /// Получение пользователя по Guid
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель передачи данных зарегистрированного пользователя.</returns>
    [HttpGet("get")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserAsync(id, cancellationToken);

        return Ok(user);
    }
}
