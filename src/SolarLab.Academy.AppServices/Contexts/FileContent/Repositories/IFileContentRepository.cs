using Microsoft.AspNetCore.Http;
using SolarLab.Academy.Contracts.FileContents;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;

/// <summary>
/// Интерфейс репозитория по работе с файлами.
/// </summary>
public interface IFileContentRepository
{
    /// <summary>
    /// Загрузка файла в репозиторий.
    /// </summary>
    /// <param name="file">Файл, отправленный с HTTP запросом.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор файла.</returns>
    Task<Guid> UploadAsync(IFormFile file, CancellationToken cancellationToken);

    /// <summary>
    /// Получение файла по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных файла для скачивания.</returns>
    Task<FileContentDto?> GetFileAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получение информации о файле по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных информации о файле.</returns>
    Task<FileContentInfoDto> GetFileInfoByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Проверка, существует ли файл в репозитории.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Вернет true, в случае если файл будет найден, иначе false.</returns>
    Task<bool> IsExistAsync(Guid id, CancellationToken cancellationToken);
}
