using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<Guid> AddAsync(CategoryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных категории, если категория будет найдена, иначе null.</returns>
    Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
