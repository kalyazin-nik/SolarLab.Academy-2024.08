using Microsoft.Extensions.Logging;
using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services;

/// <summary>
/// Сервис по работе с объявлениями.
/// </summary>
/// <param name="advertRepository">Репозиторий объявлений.</param>
/// <param name="advertSpecificationBuilder">Спецификации по поиску объявлений.</param>
/// <param name="logger">Логгер <see cref="AdvertService"/></param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class AdvertService(IAdvertRepository advertRepository,
    IAdvertSpecificationBuilder advertSpecificationBuilder,
    ILogger<AdvertService> logger,
    IStructuralLoggingService structuralLoggingService) : IAdvertService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly IAdvertSpecificationBuilder _advertSpecificationBuilder = advertSpecificationBuilder;
    private readonly ILogger<AdvertService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        return await _advertRepository.AddAsync(dto, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await GetByCategoryIdAsync(categoryId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        using var _ = _logger.BeginScope("Поиск по идентификатору: {@Id}", id);
        return await _advertRepository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySearchRequestAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("Request", request, true);
        return await _advertRepository.GetBySearchRequestAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySpecificationAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        var specification = _advertSpecificationBuilder.Build(request);

        return await _advertRepository.GetBySpecificationAsync(specification, request.Skip, request.Take, cancellationToken);
    }
}
