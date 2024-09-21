using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
/// <param name="categoryRepository">Репозиторий по работе с категорией.</param>
public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    #region Add

    public async Task<Guid> AddAsync(CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        return await _categoryRepository.AddAsync(new Category
        {
            Name = dto.Name,
            CreatedAt = DateTime.UtcNow
        }, cancellationToken);
    }

    #endregion

    #region Get

    public async Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(id, cancellationToken);

        if (category is not null)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CreatedAt = category.CreatedAt,
                ParentID = category.ParentID
            };
        }

        return null;
    }

    #endregion
}
