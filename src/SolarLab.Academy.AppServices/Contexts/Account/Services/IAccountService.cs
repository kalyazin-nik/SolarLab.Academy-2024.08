using Microsoft.AspNetCore.Http;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.Account.Services;

/// <summary>
/// Интерфейс сервиса по работе с аккаунтами пользователя.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="userRegister">Модедль регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель пользователя.</returns>
    Task<UserDto> RegisterAsync(UserRegisterRequestDto userRegister, CancellationToken cancellationToken);

    /// <summary>
    /// Вход в систему.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="UnauthorizedException"/>, если пользователь не будет найден или окажется, что пароль неверный.
    /// </remarks>
    /// <param name="loginRequest">Объект передачи данных входа пользователя в систему.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Токен для входа в систему.</returns>
    /// <exception cref="UnauthorizedException" />
    Task<string> LoginAsync(UserLoginRequestDto loginRequest, CancellationToken cancellationToken);

    /// <summary>
    /// Получить текущего пользователя.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор пользователя будет иметь значение null или по умолчанию, 
    /// который будет получен из <see cref="IHttpContextAccessor"/>.<br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется пользователь по данному идентификатору.
    /// </remarks>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель пользователя.</returns>
    /// <exception cref="BadRequestException" />
    /// <exception cref="EntityNotFoundException" />
    Task<UserDto> GetCurrentUserAsync(CancellationToken cancellationToken);
}
