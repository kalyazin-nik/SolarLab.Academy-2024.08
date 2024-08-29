using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Infrastructure.Repository;

/// <summary>
/// Интерфейс репозитория.
/// </summary>
/// <typeparam name="TEntity">Объект типа <see cref="BaseEntity"/>.</typeparam>
public interface IRepository<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Добваление новой сущности  <see cref="TEntity"/>.
    /// </summary>
    /// <param name="entity">Объект сущности  <see cref="TEntity"/>.</param>
    void Add(TEntity entity);

    /// <summary>
    /// Удаление сущности <see cref="TEntity"/> по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор сущности.</param>
    /// <returns>В случае успеха true, иначе false.</returns>
    bool Delete(Guid id);

    /// <summary>
    /// Возвращает все элементы сущности <see cref="TEntity"/>
    /// </summary>
    /// <returns>Все элементы сущности <see cref="TEntity"/></returns>
    IEnumerable<TEntity> GetAll();

    /// <summary>
    /// Возвращает элементы сущности <see cref="TEntity"/> по условию.
    /// </summary>
    /// <param name="predicate">Условие.</param>
    /// <returns>Элементы сущности <see cref="TEntity"/> удовлетворившие условие.</returns>
    IEnumerable<TEntity> GetByPredicate(Predicate<TEntity> predicate);

    /// <summary>
    /// Обновление сущности <see cref="TEntity"/>.
    /// </summary>
    /// <param name="entity">Объект сущности  <see cref="TEntity"/>.</param>
    void Update(TEntity entity);
}
