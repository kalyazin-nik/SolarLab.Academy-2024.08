using Microsoft.Extensions.Logging;
using Serilog.Context;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Validator;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services;

/// <summary>
/// Сервис по работе с объявлениями.
/// </summary>
/// <param name="advertRepository">Репозиторий объявлений.</param>
/// <param name="validationService">Сервис валидации объектов.</param>
/// <param name="logger">Логгер <see cref="AdvertService"/></param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class AdvertService(IAdvertRepository advertRepository,
    IValidationService validationService,
    ILogger<AdvertService> logger,
    IStructuralLoggingService structuralLoggingService) : IAdvertService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly IValidationService _validationService = validationService;
    private readonly ILogger<AdvertService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(AdvertCreateDto createAdvert, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("CreateAdvert", createAdvert, true);
        _logger.LogInformation("Создание объявления: {@createAdvert}", createAdvert);
        await _validationService.BeforExecuteRequestValidate_ExistCategoryAsync(createAdvert.CategoryId, cancellationToken);

        return await _advertRepository.CreateAsync(createAdvert, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>> GetByCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetAdvertsByCategoryId", id!);
        _logger.LogInformation("Поиск объявлений по идентификатору категории: {@id}", id);
        _validationService.BeforeExecuteRequestValidate_Id(id);
        var collection = await _advertRepository.GetByCategoryIdAsync(id!.Value, cancellationToken);
        collection = _validationService.AfterExecuteRequestValidate_AdvertSmallCollection(collection);

        return collection;
    }

    /// <inheritdoc />
    public async Task<AdvertDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetAdvertById", id!);
        _logger.LogInformation("Поиск объявления по идентификатору: {@Id}", id);
        id = _validationService.BeforeExecuteRequestValidate_Id(id);
        var advert = await _advertRepository.GetByIdAsync(id.Value, cancellationToken);
        advert = _validationService.AfterExecuteRequestValidate_Advert(advert);

        return advert;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken)
    {
        using var _ = LogContext.PushProperty("Request", request, true);
        _logger.LogInformation("Поиск объявлений по запросу");
        var advertResponse = await _advertRepository.GetBySearchRequestAsync(request, cancellationToken);
        advertResponse = _validationService.AfterExecuteRequestValidate_AdvertSmallCollection(advertResponse);

        return advertResponse;
    }
}
