using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Account.Services;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер учётных записей.
/// </summary>
/// <param name="accountService">Сервис по работе с учетными записями.</param>
[ApiController]
[Route("accounts")]
[AllowAnonymous]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="model">Модель передачи данных регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель передачи данных зарегистрированного пользователя.</returns>
    [HttpPost]
    [Route("register")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var user = await _accountService.RegisterAsync(model, cancellationToken);

        return Ok(user);
    }

    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="model">Объект передачи данных запроса авторизации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Токен авторизации.</returns>
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto model, CancellationToken cancellationToken)
    {
        var result = await _accountService.LoginAsync(model, cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Получение информации о текущем пользователе.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    [HttpGet]
    [Route("get/user/info")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCurrentUserInfoAsync(CancellationToken cancellationToken)
    {
        var user = await _accountService.GetCurrentUserAsync(cancellationToken);

        return Ok(user);
    }
}
