using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Validator.Service;

public interface ICategoryValidatorService
{
    /// <summary>
    /// Проверка модели объявления <see cref="CategoryDto"/>, допускающего значение null, после выполнения запроса к репозиторию.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления <see cref="CategoryDto"/> имеет значение null.
    /// </remarks>
    /// <param name="category">Модель объявления.</param>
    /// <returns>Утвержденная модель объявления <see cref="CategoryDto"/>.</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    CategoryDto AfterExecuteRequestValidate_Category(CategoryDto? category);

    /// <summary>
    /// Проверка идентификатора, допускающего значение null, перед выполнением запроса к репозиторию. 
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Утвержденный идентификатор.</returns>
    /// <exception cref="BadRequestException"></exception>
    Guid BeforeExecuteRequestValidate_Id(Guid? id);

    /// <summary>
    /// Проверка, существует ли идентификатор категории в репозитории.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор будет иметь значение null или по умолчанию.
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется категория по данному идентификатору.
    /// </remarks>
    /// <param name="id">Идентификатор категории.</param>
    /// <returns>Вернет true, если модель категории будет найдена.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<bool> BeforExecuteRequestValidate_ExistCategoryIdAsync(Guid? id, CancellationToken cancellationToken);
}
