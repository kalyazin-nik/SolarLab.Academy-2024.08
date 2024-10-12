using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <summary>
/// Репозиторий для работы с объявлениями.
/// </summary>
/// <param name="repository">Репозиторий.</param>
/// <param name="mapper">Маппер.</param>
public class AdvertRepository(IRepository<Advert, AcademyDbContext> repository, IMapper mapper) : IAdvertRepository
{
    private readonly IRepository<Advert, AcademyDbContext> _repository = repository;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc />
    public async Task<Guid> CreateAsync(CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        var advert = _mapper.Map<CreateAdvertDto, Advert>(dto);
        await _repository.AddAsync(advert, cancellationToken);

        return advert.Id;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.CategoryId == categoryId)
            .OrderBy(x => x.CreatedAt)
            .ProjectTo<ShortAdvertDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<AdvertDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var advert = await _repository.GetByIdAsync(id, cancellationToken);

        if (advert is not null)
        {
            return _mapper.Map<Advert, AdvertDto>(advert);
        }

        return null;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySearchRequestAsync(SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll()
            .OrderBy(x => x.Id)
            .Where(x => request.IncludeDisabled.GetValueOrDefault(false) || !x.Disabled);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            query = query.Where(x => x.Name.ToLower().Contains(request.Search.ToLower()) || x.Description.ToLower().Contains(request.Search.ToLower()));
        }

        if (request.MinPrice.HasValue)
        {
            query = query.Where(x => x.Price >= request.MinPrice.Value);
        }

        if (request.MaxPrice.HasValue)
        {
            query = query.Where(x => x.Price <= request.MaxPrice.Value);
        }

        if (request.Skip.HasValue)
        {
            query = query.Skip(request.Skip.Value);
        }

        return await query.Take(request.Take)
            .ProjectTo<ShortAdvertDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<ShortAdvertDto>> GetBySpecificationAsync(ISpecification<Advert> specification, int? skip, int take, CancellationToken cancellationToken)
    {
        var query = _repository.GetAll()
            .OrderBy(x => x.Id)
            .Where(specification.PredicateExpression);

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        return await query.Take(take)
            .ProjectTo<ShortAdvertDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }
}
