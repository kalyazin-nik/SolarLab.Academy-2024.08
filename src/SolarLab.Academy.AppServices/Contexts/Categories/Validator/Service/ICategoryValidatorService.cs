using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Validator.Service;

public interface ICategoryValidatorService
{
    /// <summary>
    /// Проверка модели категории <see cref="CategoryDto"/>, допускающего значение null, после выполнения запроса к репозиторию.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель категории <see cref="CategoryDto"/> имеет значение null.
    /// </remarks>
    /// <param name="category">Модель категории.</param>
    /// <returns>Утвержденная модель категории <see cref="CategoryDto"/>.</returns>
    /// <exception cref="EntityNotFoundException" />
    CategoryDto AfterExecuteRequestValidate_Category(CategoryDto? category);

    /// <summary>
    /// Проверка идентификатора, допускающего значение null, перед выполнением запроса к репозиторию. 
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Утвержденный идентификатор.</returns>
    /// <exception cref="BadRequestException" />
    Guid BeforeExecuteRequestValidate_Id(Guid? id);

    /// <summary>
    /// Проверка, существует ли модель категории в репозитории по данному идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор будет иметь значение null или по умолчанию.<br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется категория по данному идентификатору.
    /// </remarks>
    /// <param name="id">Идентификатор категории.</param>
    /// <returns>Вернет true, если модель категории будет найдена.</returns>
    /// <exception cref="BadRequestException" />
    /// <exception cref="EntityNotFoundException" />
    Task<bool> BeforExecuteRequestValidate_ExistCategoryAsync(Guid? id, CancellationToken cancellationToken);
}
