using Microsoft.AspNetCore.Http;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.FileContents;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Services;

/// <summary>
/// Интерфейс сервиса по работе с файлами.
/// </summary>
public interface IFileContentService
{
    /// <summary>
    /// Загрузка файла в репозиторий.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, в случае, если: файл со значением null или пуст,<br />
    /// тип контента не будет соответсвовать типу фотографи, размер файла будет больше 2 мегабайт или равен нулю.
    /// </remarks>
    /// <param name="file">Файл, отправленный с HTTP запросом.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор файла.</returns>
    /// <exception cref="BadRequestException" />
    Task<Guid> UploadAsync(IFormFile? file, CancellationToken cancellationToken);

    /// <summary>
    /// Получение файла по идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор будет иметь значение null или по умолчанию.<br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется файл по данному идентификатору.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель файла для скачивания.</returns>
    /// <exception cref="BadRequestException" />
    /// <exception cref="EntityNotFoundException" />
    Task<FileContentDto> GetFileAsync(Guid? id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение информации о файле по идентификатору.
    /// </summary>
    /// <remarks>
    /// Будет выбрашено исключение <see cref="BadRequestException"/>, если идентификатор будет иметь значение null или по умолчанию.<br />
    /// Также будет выбрашено исключение <see cref="EntityNotFoundException"/>, если в репозитории не найдется файл по данному идентификатору.
    /// </remarks>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Модель информации о файле.</returns>
    /// <exception cref="BadRequestException" />
    /// <exception cref="EntityNotFoundException" />
    Task<FileContentInfoDto> GetFileInfoByIdAsync(Guid? id, CancellationToken cancellationToken);
}
