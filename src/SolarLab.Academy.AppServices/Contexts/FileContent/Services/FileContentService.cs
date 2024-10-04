using Microsoft.AspNetCore.Http;
using SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;
using SolarLab.Academy.Contracts.FileContents;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Services;

/// <summary>
/// Сервис по работе с файлами.
/// </summary>
/// <param name="repository">Репозиторий по работе с файлами.</param>
public class FileContentService(IFileContentRepository repository) : IFileContentService
{
    private readonly IFileContentRepository _repository = repository;

    /// <inheritdoc />
    public async Task<Guid> UploadAsync(IFormFile file, CancellationToken cancellationToken)
    {
        var bytes = await GetBytesAsync(file, cancellationToken);
        var fileContentDto = new FileContentDto
        {
            Name = file.FileName,
            ContentType = file.ContentType,
            Content = bytes
        };

        return await _repository.UploadAsync(fileContentDto, cancellationToken);
    }

    /// <inheritdoc />
    private static async Task<byte[]> GetBytesAsync(IFormFile file, CancellationToken cancellationToken)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream, cancellationToken);

        return memoryStream.ToArray();
    }

    /// <inheritdoc />
    public async Task<FileContentDto?> GetFileAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetFileAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileContentInfoDto?> GetFileInfoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetFileInfoByIdAsync(id, cancellationToken);
    }
}
