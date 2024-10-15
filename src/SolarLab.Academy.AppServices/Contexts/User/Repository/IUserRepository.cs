using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Repository;

/// <summary>
/// Интерфейс репоозитория по работе с пользователями.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Регистрация пользователя.
    /// </summary>
    /// <param name="userRegister">Модель регистрации пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель пользователя.</returns>
    Task<UserDto> RegisterAsync(UserRegisterRequestDto userRegister, CancellationToken cancellationToken);

    /// <summary>
    /// Плучение всех пользователей.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объектов передачи данных пользователей.</returns>
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных пользователя.</returns>
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по логину.
    /// </summary>
    /// <param name="dto">Объект передачи данных входа пользователя в систему.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных ответа запроса логина пользователя.</returns>
    Task<UserLoginResponseDto?> GetByLoginAsync(UserLoginRequestDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка, существует ли пользователь в репозитории.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Вернет true, в случае если пользователь будет найден, иначе false.</returns>
    Task<bool> IsExistAsync(Guid id, CancellationToken cancellationToken);
}
