using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Services;

/// <summary>
/// Сервис по работе с пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Получение всех пользователей.
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
    Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
}
