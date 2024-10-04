using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.User.Services;
using SolarLab.Academy.Contracts.User;
using System.Net;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с пользователями.
/// </summary>
/// <param name="userService">Сервис по работе с пользователями.</param>
/// <param name="logger">Логгер <see cref="UserController"/></param>
[Route("users")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly ILogger<UserController> _logger = logger;

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
        var user = await _userService.GetUserByIdAsync(id, cancellationToken);

        return Ok(user);
    }
}
