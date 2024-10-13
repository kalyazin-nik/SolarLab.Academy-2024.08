using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <remarks>
    /// ВАЖНО!!! Если у передаваемой модели поле ParentId будет иметь значение null, то проверки на значение по умолчанию и существование записи по этому 
    /// идентификатору проводиться не будут.
    /// <br /><br />
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если, у передаваемой модели,
    /// идентификатор родительской категории окажется со значением по умолчанию. Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, 
    /// если по идентификатору родительской категории не окажется записи в репозитории.
    /// </remarks>
    /// <param name="createCategory">Модель создания категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<Guid> AddAsync(CategoryCreateDto createCategory, CancellationToken cancellationToken);

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию. 
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель категории отстутствует в репозитории.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель категории.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<CategoryDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken);
}
