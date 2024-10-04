using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
/// <param name="categoryRepository">Репозиторий по работе с категорией.</param>
public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        return await _categoryRepository.AddAsync(dto, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetByIdAsync(id, cancellationToken);
    }
}
