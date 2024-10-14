using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Validator;
using SolarLab.Academy.Contracts.FileContents;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Services;

/// <summary>
/// Сервис по работе с файлами.
/// </summary>
/// <param name="repository">Репозиторий по работе с файлами.</param>
public class FileContentService(
    IFileContentRepository repository,
    IValidationService validationService,
    ILogger<FileContentService> logger,
    IStructuralLoggingService structuralLoggingService) : IFileContentService
{
    private readonly IFileContentRepository _repository = repository;
    private readonly IValidationService _validationService = validationService;
    private readonly ILogger<FileContentService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> UploadAsync(IFormFile? file, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("File", file!, true);
        _logger.LogInformation("Создание объявления: {@file}", file);
        file = await _validationService.BeforeExecuteRequestValidate_IFormFileAsync(file, cancellationToken);

        return await _repository.UploadAsync(file, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileContentDto> GetFileAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("Id", id!);
        _logger.LogInformation("Скачивание файла: {@id}", id);
        id = await _validationService.BeforExecuteRequestValidate_ExistFileAsync(id, cancellationToken);

        return await _repository.GetFileAsync(id.Value, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileContentInfoDto> GetFileInfoByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("Id", id!);
        _logger.LogInformation("Получение информации о файле: {@id}", id);
        id = await _validationService.BeforExecuteRequestValidate_ExistFileAsync(id, cancellationToken);

        return await _repository.GetFileInfoByIdAsync(id.Value, cancellationToken);
    }
}
