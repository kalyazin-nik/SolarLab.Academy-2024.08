using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;

public interface IAdvertValidatorService
{
    /// <summary>
    /// Проверка коллекции моделей объявлений <see cref="AdvertSmallDto"/>, допускающей значение null или пусто, после выполнения запроса к репозиторию.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="EntitiesNotFoundException"/>, в случае, 
    /// если коллекция моделей объявлений <see cref="AdvertSmallDto"/> окажется со значением null или пустой.
    /// </remarks>
    /// <param name="collection">Коллекция моделей объявлений.</param>
    /// <returns>Утвержденная коллекция моделей <see cref="AdvertSmallDto"/>.</returns>
    /// <exception cref="EntitiesNotFoundException" />
    IReadOnlyCollection<AdvertSmallDto> AfterExecuteRequestValidate_Collection(IReadOnlyCollection<AdvertSmallDto>? collection);

    /// <summary>
    /// Проверка модели объявления <see cref="AdvertDto"/>, допускающая значение null, после выполнения запроса к репозиторию.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления <see cref="AdvertDto"/> будет со значением null.
    /// </remarks>
    /// <param name="advert">Модель объявления.</param>
    /// <returns>Утвержденная модель объявления <see cref="AdvertDto"/>, что не имеет значение null.</returns>
    /// <exception cref="EntityNotFoundException" />
    AdvertDto AfterExecuteRequestValidate_Advert(AdvertDto? advert);

    /// <summary>
    /// Проверка идентификатора, допускающего значение null, перед выполнением запроса к репозиторию. 
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если идентификатор окажется со значением null или по умолчанию.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Утвержденный идентификатор, что не имеет значение null.</returns>
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
