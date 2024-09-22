using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <summary>
/// Репозиторий для работы с категориями.
/// </summary>
/// <param name="repository">Репозиторий.</param>
/// <param name="mapper">Маппер.</param>
public class CategoryRepository(IRepository<Category, AcademyDbContext> repository, IMapper mapper) : ICategoryRepository
{
    private readonly IRepository<Category, AcademyDbContext> _repository = repository;
    private readonly IMapper _mapper = mapper;

    #region Add

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<CategoryCreateDto, Category>(dto);
        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }

    #endregion

    #region Get

    /// <inheritdoc />
    public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }

    #endregion

}
