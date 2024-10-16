using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Account.Services;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Error;
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
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        return Ok(await _accountService.RegisterAsync(model, cancellationToken));
    }

    /// <summary>
    /// Авторизация пользователя.
    /// </summary>
    /// <param name="loginRequest">Модель запроса авторизации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Токен авторизации.</returns>
    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(UnauthorizedError), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequestDto loginRequest, CancellationToken cancellationToken)
    {
        return Ok(await _accountService.LoginAsync(loginRequest, cancellationToken));
    }

    /// <summary>
    /// Получение информации о текущем пользователе.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель пользователя.</returns>
    [HttpGet]
    [Route("get/current-user")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(EntityNotFoundException), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetCurrentUserInfoAsync(CancellationToken cancellationToken)
    {
        return Ok(await _accountService.GetCurrentUserAsync(cancellationToken));
    }
}
