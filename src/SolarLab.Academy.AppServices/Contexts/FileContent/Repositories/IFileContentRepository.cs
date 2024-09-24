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
    /// <param name="fileContentDto">Объект передачи данных файла.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор файла.</returns>
    Task<Guid> UploadAsync(FileContentDto fileContentDto, CancellationToken cancellationToken);

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
