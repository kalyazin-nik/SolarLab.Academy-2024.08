using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Infrastructure.Repository;

/// <summary>
/// Репозиторий.
/// </summary>
/// <typeparam name="TEntity">Сущность хранимая в репозитории.</typeparam>
/// <typeparam name="TContext">Контекст подключения к репозиторию.</typeparam>
public interface IRepository<TEntity, TContext>
    where TEntity : EntityBase
    where TContext : DbContext
{
    /// <summary>
    /// Добваление.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает все сущности <see cref="TEntity"/>.
    /// </summary>
    /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
    IQueryable<TEntity> GetAll();

    /// <summary>
    /// Получение сущности <see cref="TEntity"/> по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Сущность <see cref="TEntity"/></returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает сущности <see cref="TEntity"/> согласно условию.
    /// </summary>
    /// <param name="predicate">Условие.</param>
    /// <returns></returns>
    IQueryable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Удаление.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task RemoveAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}
