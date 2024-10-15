﻿using Microsoft.AspNetCore.Http;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Enums;

namespace SolarLab.Academy.AppServices.Validator;

public interface IValidationService
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
    IReadOnlyCollection<AdvertSmallDto> AfterExecuteRequestValidate_AdvertSmallCollection(IReadOnlyCollection<AdvertSmallDto>? collection);

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
    /// Проверка файла отправленного с HttpRequest.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если: файл со значением null или пуст,<br />
    /// тип контента не будет соответсвовать типу фотографи, размер файла будет больше 2 мегабайт или равен нулю.
    /// </remarks>
    /// <param name="file">Файл отправленный с HttpRequest.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Утвержденный файл.</returns>
    /// <exception cref="BadRequestException" />
    Task<IFormFile> BeforeExecuteRequestValidate_IFormFileAsync(IFormFile? file, CancellationToken cancellationToken);

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
    /// Проверка, существует ли сущность в репозитории по данному идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор пользователя будет иметь значение null или по умолчанию.<br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется сущность по данному идентификатору.<br />
    /// Исключение <see cref="NotImplementedException"/> будет выбрашено в случае, если аргументом передастся тип репозитория <see cref="RepositoriesTypes"/> не добавленный в сервис.
    /// </remarks>
    /// <param name="id">Идентификатор файла.</param>
    /// <returns>Утвержденный идентификатор.</returns>
    /// <exception cref="BadRequestException" />
    /// <exception cref="EntityNotFoundException" />
    /// <exception cref="NotImplementedException" />
    Task<Guid> BeforExecuteRequestValidate_ExistEntityAsync(RepositoriesTypes repositoryType, Guid? id, CancellationToken cancellationToken);
}
