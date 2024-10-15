namespace SolarLab.Academy.AppServices.Services;

/// <summary>
/// Базовый репозиторий.
/// </summary>
public interface IBaseRepository
{
    /// <summary>
    /// Проверка, существует ли сущность в репозитории.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Вернет true, в случае если сущность будет найдена, иначе false.</returns>
    Task<bool> IsExistAsync(Guid id, CancellationToken cancellationToken);
}
