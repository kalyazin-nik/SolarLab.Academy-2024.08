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
    /// <param name="dto">Объект передачи данных регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    Task<UserDto> RegisterAsync(UserRegisterRequestDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Вход в систему.
    /// </summary>
    /// <param name="dto">Объект передачи данных входа пользователя в систему.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Токен для входа в систему.</returns>
    Task<string> LoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получить текущего пользователя.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    Task<UserDto?> GetCurrentUserAsync(CancellationToken cancellationToken);
}
