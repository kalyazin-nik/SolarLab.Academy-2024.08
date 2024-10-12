using Microsoft.Extensions.Logging;
using Serilog.Context;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services;

/// <summary>
/// Сервис по работе с объявлениями.
/// </summary>
/// <param name="advertRepository">Репозиторий объявлений.</param>
/// <param name="validatorService">Сервис валидации объектов.</param>
// /// <param name="advertSpecificationBuilder">Спецификации по поиску объявлений.</param>
/// <param name="logger">Логгер <see cref="AdvertService"/></param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class AdvertService(IAdvertRepository advertRepository,
    IAdvertValidatorService validatorService,
   // IAdvertSpecificationBuilder advertSpecificationBuilder,
    ILogger<AdvertService> logger,
    IStructuralLoggingService structuralLoggingService) : IAdvertService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly IAdvertValidatorService _validatorService = validatorService;
   // private readonly IAdvertSpecificationBuilder _advertSpecificationBuilder = advertSpecificationBuilder;
    private readonly ILogger<AdvertService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(AdvertCreateDto createAdvert, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("CreateAdvert", createAdvert, true);
        _logger.LogInformation("Создание объявления: {@createAdvert}", createAdvert);

        await _validatorService.ValidateCategoryIdForAdvertAsync(createAdvert.CategoryId!.Value, cancellationToken);
        return await _advertRepository.CreateAsync(createAdvert, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>> GetByCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetAdvertsByCategoryId", id!);
        _logger.LogInformation("Поиск объявлений по идентификатору категории: {@id}", id);
        await _validatorService.ValidateCategoryIdForAdvertAsync(id, cancellationToken);
        return await _advertRepository.GetByCategoryIdAsync(id!.Value, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AdvertDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetAdvertById", id!);
        _logger.LogInformation("Поиск объявления по идентификатору: {@Id}", id);
        await _validatorService.ValidateIdForAdvertAsync(id, cancellationToken);
        return await _advertRepository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken)
    {
        using var _ = LogContext.PushProperty("Request", request, true);
        _logger.LogInformation("Поиск объявлений по запросу");

        return await _advertRepository.GetBySearchRequestAsync(request, cancellationToken);
    }
}
