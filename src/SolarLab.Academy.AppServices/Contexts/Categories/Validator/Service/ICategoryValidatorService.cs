using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Validator.Service;

public interface ICategoryValidatorService
{
    /// <summary>
    /// Проверка модели объявления <see cref="CategoryDto"/>, допускающего значение null, после выполнения запроса к репозиторию.
    /// </summary>
    /// <param name="category">Модель объявления.</param>
    /// <returns>Утвержденная модель объявления <see cref="CategoryDto"/>, что не имеет значение null.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления <see cref="CategoryDto"/> будет со значением null.</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    CategoryDto AfterExecuteRequestValidate_Category(CategoryDto? category);

    /// <summary>
    /// Проверка идентификатора, допускающего значение null, перед выполнением запроса к репозиторию. 
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Утвержденный идентификатор, что не имеет значение null.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.</returns>
    /// <exception cref="BadRequestException"></exception>
    Guid BeforeExecuteRequestValidate_Id(Guid? id);

    /// <summary>
    /// Проверка, существует ли идентификатор категории в репозитории.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <returns>Если модель категории будет найдена, то вернет true, иначе будет выбрашено исключение <see cref="EntityNotFoundException"/>.
    /// 
    /// <br/><br/>Также, если идентификатор будет иметь значение null или по умолчанию будет выбрашено исключение <see cref="BadRequestException"/>.</returns>
    /// <exception cref="BadRequestException"></exception>
    /// <exception cref="EntityNotFoundException"></exception>
    Task<bool> BeforExecuteRequestValidate_ExistCategoryIdAsync(Guid? id, CancellationToken cancellationToken);
}
