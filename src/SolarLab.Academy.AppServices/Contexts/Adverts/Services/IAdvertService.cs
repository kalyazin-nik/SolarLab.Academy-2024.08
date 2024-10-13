using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.AppServices.Exceptions;
namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services;

/// <summary>
/// Интерфейс сервиса по работе с объявлениями.
/// </summary>
public interface IAdvertService
{
    /// <summary>
    /// Создает объявление по модели запроса.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если, у передаваемой модели, идентификатор окажется со значением null или по умолчанию. <br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель категории отстутствует в репозитории.
    /// </remarks>
    /// <param name="dto">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<Guid> CreateAsync(AdvertCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по идентификатору категории.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.<br/>
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель категории отстутствует в репозитории.
    /// </remarks>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция сокращенных моделей объявления.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntitiesNotFoundException"></exception>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetByCategoryIdAsync(Guid? categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Получает объявление по идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.<br/>
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления отстутствует в репозитории.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<AdvertDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="EntitiesNotFoundException"/>, в случае, если полученная коллекция от репозитория будет иметь значение null или пусто.
    /// </remarks>
    /// <param name="request">Тело запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    /// <exception cref="EntitiesNotFoundException"></exception>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken);
}
