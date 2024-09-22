using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;

/// <summary>
/// Репозиторий для работы с объявлнеиями.
/// </summary>
public interface IAdvertRepository
{
    #region Add

    /// <summary>
    /// Создает объявление по модели запроса.
    /// </summary>
    /// <param name="dto">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    Task<Guid> AddAsync(CreateAdvertDto dto, CancellationToken cancellationToken);

    #endregion

    #region Get

    /// <summary>
    /// Выполняет получение объявлений по идентификатору категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция сокращенных моделей объявления.</returns>
    Task<IReadOnlyCollection<ShortAdvertDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Получает объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Тело запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    Task<IReadOnlyCollection<ShortAdvertDto>> GetBySearchRequestAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по спецификации запроса.
    /// </summary>
    /// <param name="specification">Спецификация запроса.</param>
    /// <param name="skip">Количество элементов для пропуска.</param>
    /// <param name="take">Количество элементов для выдачи.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    Task<IReadOnlyCollection<ShortAdvertDto>> GetBySpecificationAsync(ISpecification<Advert> specification, int? skip, int take, CancellationToken cancellationToken);

    #endregion
}
