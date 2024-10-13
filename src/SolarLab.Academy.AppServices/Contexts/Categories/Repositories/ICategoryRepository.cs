using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Repositories;

/// <summary>
/// Репозиторий по работе с категорией.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Добавление категории в репозиторий.
    /// </summary>
    /// <param name="category">Категория.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<Guid> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Категория. Вернётся null, если категория не будет найдена.</returns>
    Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
