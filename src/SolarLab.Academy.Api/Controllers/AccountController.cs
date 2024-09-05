using System.Net;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Account.Services;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Учётные записи.
/// </summary>
/// <remarks>
/// Конструктор.
/// </remarks>
/// <param name="accountService"></param>
[ApiController]
[Route("accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    private readonly IAccountService _accountService = accountService;

    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="model">Модель передачи данных регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель передачи данных зарегистрированного пользователя.</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)] // возврат статус кода 200
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)] // возврат статус кода 500
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var user = await _accountService.RegisterAsync(model, cancellationToken);

        return Ok(user);
    }

    //public async Task<IActionResult> Login(CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}
}
