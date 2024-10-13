using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;

public interface IAdvertValidatorService
{
    /// <summary>
    /// Проверка коллекции моделей объявлений <see cref="AdvertSmallDto"/>, допускающей значение null или пусто, после выполнения запроса к репозиторию.
    /// </summary>
    /// <param name="collection">Коллекция моделей объявлений.</param>
    /// <returns>Утвержденная коллекция моделей <see cref="AdvertSmallDto"/>.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="EntitiesNotFoundException"/>, в случае, 
    /// если коллекция моделей объявлений <see cref="AdvertSmallDto"/> окажется со значением null или пустой.</returns>
    /// <exception cref="EntitiesNotFoundException"></exception>
    IReadOnlyCollection<AdvertSmallDto> AfterExecuteRequestValidate_Collection(IReadOnlyCollection<AdvertSmallDto>? collection);

    /// <summary>
    /// Проверка модели объявления <see cref="AdvertDto"/>, допускающего значение null, после выполнения запроса к репозиторию.
    /// </summary>
    /// <param name="advert">Модель объявления.</param>
    /// <returns>Утвержденная модель объявления <see cref="AdvertDto"/>, что не имеет значение null.
    /// 
    /// <br/><br/>Будет выбрашено исключение <see cref="EntityNotFoundException"/>, в случае, если модель объявления <see cref="AdvertDto"/> будет со значением null.</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    AdvertDto AfterExecuteRequestValidate_Advert(AdvertDto? advert);

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
