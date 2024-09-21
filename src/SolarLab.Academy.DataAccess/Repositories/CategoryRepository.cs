using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

/// <inheritdoc />
public class CategoryRepository(IRepository<Category, AcademyDbContext> repository) : ICategoryRepository
{
    private readonly IRepository<Category, AcademyDbContext> _repository = repository;

    #region Add

    public async Task<Guid> AddAsync(Category category, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(category, cancellationToken);

        return category.Id;
    }

    #endregion

    #region Get

    public async Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    #endregion

}
