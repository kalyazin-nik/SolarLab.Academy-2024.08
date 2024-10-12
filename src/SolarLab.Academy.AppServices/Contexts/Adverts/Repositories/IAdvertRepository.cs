using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;

/// <summary>
/// Репозиторий для работы с объявлнеиями.
/// </summary>
public interface IAdvertRepository
{
    /// <summary>
    /// Создает объявление по модели запроса.
    /// </summary>
    /// <param name="advertCreate">Модель запроса создания объявления..</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<Guid> CreateAsync(AdvertCreateDto advertCreate, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по идентификатору категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция сокращенных моделей объявления.</returns>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Получает объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AdvertDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Тело запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken);
}
