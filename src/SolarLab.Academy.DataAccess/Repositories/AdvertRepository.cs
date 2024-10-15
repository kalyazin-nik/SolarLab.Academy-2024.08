using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Adverts.Builders;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <summary>
/// Репозиторий для работы с объявлениями.
/// </summary>
/// <param name="repository">Репозиторий.</param>
/// <param name="mapper">Маппер.</param>
public class AdvertRepository(
    IRepository<Advert, AcademyDbContext> repository,
    IAdvertSpecificationBuilder advertSpecificationBuilder,
    IMapper mapper) : IAdvertRepository
{
    private readonly IRepository<Advert, AcademyDbContext> _repository = repository;
    private readonly IAdvertSpecificationBuilder _advertSpecificationBuilder = advertSpecificationBuilder;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(AdvertCreateDto dto, CancellationToken cancellationToken)
    {
        var advert = _mapper.Map<AdvertCreateDto, Advert>(dto);
        await _repository.AddAsync(advert, cancellationToken);
        return advert.Id;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>?> GetByCategoryIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository
            .GetByPredicate(x => x.CategoryId == id)
            .OrderBy(x => x.CreatedAt)
            .ProjectTo<AdvertSmallDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AdvertDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var advert = await _repository.GetByIdAsync(id, cancellationToken);
        return _mapper.Map<Advert, AdvertDto>(advert);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<AdvertSmallDto>?> GetBySearchRequestAsync(AdvertSearchRequestDto request, CancellationToken cancellationToken)
    {
        var specification = _advertSpecificationBuilder.Build(request);
        var skip = request.Skip;
        var take = request.Take;

        var query = _repository.GetAll()
            .OrderBy(x => x.CreatedAt)
            .Where(specification.PredicateExpression);

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        return await query.Take(take)
            .ProjectTo<AdvertSmallDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> IsExistAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.IsExistAsync(id, cancellationToken);
    }
}
