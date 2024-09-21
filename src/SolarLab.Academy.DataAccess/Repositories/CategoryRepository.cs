using AutoMapper;
using AutoMapper.QueryableExtensions;
using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <inheritdoc />
public class CategoryRepository(IRepository<Category, AcademyDbContext> repository, IMapper mapper) : ICategoryRepository
{
    private readonly IRepository<Category, AcademyDbContext> _repository = repository;
    private readonly IMapper _mapper = mapper;

    #region Add

    public async Task<Guid> AddAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<CategoryCreateDto, Category>(dto);
        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }

    #endregion

    #region Get

    public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_repository.GetAll()
            .Where(x => x.Id == id)
            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            .FirstOrDefault()
        );
    }

    #endregion

}
