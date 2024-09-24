using Microsoft.AspNetCore.Http;
using SolarLab.Academy.Contracts.FileContents;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Services;

/// <summary>
/// Интерфейс сервиса по работе с файлами.
/// </summary>
public interface IFileContentService
{
    /// <summary>
    /// Загрузка файла в систему.
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
    Task<FileContentInfoDto?> GetFileInfoByIdAsync(Guid id, CancellationToken cancellationToken);
}
