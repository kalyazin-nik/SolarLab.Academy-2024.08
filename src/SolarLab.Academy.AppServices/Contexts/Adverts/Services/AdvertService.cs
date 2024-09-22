using SolarLab.Academy.AppServices.Contexts.Adverts.Builders;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Services;

/// <summary>
/// Сервис по работе с объявлениями.
/// </summary>
/// <param name="advertRepository">Репозиторий объявлений.</param>
public class AdvertService(IAdvertRepository advertRepository, IAdvertSpecificationBuilder advertSpecificationBuilder) : IAdvertService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly IAdvertSpecificationBuilder _advertSpecificationBuilder = advertSpecificationBuilder;

    #region Add

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        return await _advertRepository.AddAsync(dto, cancellationToken);
    }

    #endregion

    #region Get

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await GetByCategoryIdAsync(categoryId, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _advertRepository.GetByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySearchRequestAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        return await _advertRepository.GetBySearchRequestAsync(request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySpecificationAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        var specification = _advertSpecificationBuilder.Build(request);

        return await _advertRepository.GetBySpecificationAsync(specification, request.Skip, request.Take, cancellationToken);
    }

    #endregion
}
