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
    /// <param name="dto">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданного объявления.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если, у передаваемой модели,
    /// идентификатор окажется со значением null или по умолчанию. Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, 
    /// если модель категории отстутствует в репозитории.</returns>
    /// <exception cref="BadRequestException">В случае, если, у передаваемой модели, идентификатор категории будет со значением null или по умолчанию.</exception>
    /// <exception cref="EntityNotFoundException">В случае, если модель категории будет отсутствовать в репозитории.</exception>
    Task<Guid> CreateAsync(AdvertCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по идентификатору категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция сокращенных моделей объявления.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор 
    /// окажется со значением null или по умолчанию. Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель категории отстутствует в репозитории.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntitiesNotFoundException"></exception>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetByCategoryIdAsync(Guid? categoryId, CancellationToken cancellationToken);

    /// <summary>
    /// Получает объявление по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель объявления.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию. 
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления отстутствует в репозитории.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<AdvertDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken);

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Тело запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="EntitiesNotFoundException"/>, 
    /// в случае, если полученная коллекция от репозитория будет иметь значение null или пусто.</returns>
    /// <exception cref="EntitiesNotFoundException"></exception>
    Task<IReadOnlyCollection<AdvertSmallDto>> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken);
}
