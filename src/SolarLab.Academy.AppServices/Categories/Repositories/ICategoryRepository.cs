using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Categories.Repositories;

/// <summary>
/// Репозиторий по работе с категорией.
/// </summary>
public interface ICategoryRepository
{
    #region Add

    /// <summary>
    /// Добавление категории в репозиторий.
    /// </summary>
    /// <param name="category">Категория.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    Task<Guid> AddAsync(Category category, CancellationToken cancellationToken);

    #endregion

    #region Get

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Категория. Вернётся null, если категория не будет найдена.</returns>
    Task<Category?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    #endregion
}
