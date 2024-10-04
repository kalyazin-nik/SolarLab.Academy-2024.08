using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications.Internal;

namespace SolarLab.Academy.AppServices.Specifications;

/// <summary>
/// Базовый класс спецификации.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    #region Field

    /// <summary>
    /// Спецификация со значением истины для любого входного параметра.
    /// </summary>
    public static readonly Specification<TEntity> True = new ExpressionSpecification<TEntity>(_ => true);

    /// <summary>
    /// Спецификация со значением ложь для любого входного параметра.
    /// </summary>
    public static readonly Specification<TEntity> False = new ExpressionSpecification<TEntity>(_ => false);

    #endregion

    #region Property

    /// <summary>
    /// Провайдер скомилированного выражения предиката.
    /// Необходим чтобы не компилировать дерево каждый раз при проверке объекта.
    /// </summary>
    protected Lazy<Func<TEntity, bool>> CompiledPredicateProvider { get; }

    /// <inheritdoc />
    public abstract Expression<Func<TEntity, bool>> PredicateExpression { get; }

    #endregion

    /// <summary>
    /// Инициализирует экземпляр <see cref="Specification{TEntity}"/>.
    /// </summary>
    protected Specification()
    {
        CompiledPredicateProvider = new Lazy<Func<TEntity, bool>>(() => PredicateExpression.Compile());
    }

    /// <inheritdoc />
    public bool IsSatisfiedBy(TEntity entity)
    {
        var predicate = CompiledPredicateProvider.Value;

        return predicate(entity);
    }

    /// <summary>
    /// Создает спецификацию из предиката.
    /// </summary>
    /// <param name="predicate">Предикат.</param>
    /// <returns>Спецификация.</returns>
    public static Specification<TEntity> FromPredicate(Expression<Func<TEntity, bool>> predicate)
    {
        return new ExpressionSpecification<TEntity>(predicate);
    }

    #region Operator

    /// <summary>
    /// Оператор приведения типа к дереву выражений.
    /// </summary>
    /// <param name="specification">Спецификация.</param>
    /// <returns>Дерево выражений.</returns>
    public static implicit operator Expression<Func<TEntity, bool>>(Specification<TEntity> specification)
    {
        return specification.PredicateExpression;
    }

    /// <summary>
    /// Операция "ИЛИ".
    /// </summary>
    public static Specification<TEntity> operator |(Specification<TEntity> left, Specification<TEntity> right)
    {
        return left.Or(right);
    }

    /// <summary>
    /// Операция "И".
    /// </summary>
    public static Specification<TEntity> operator &(Specification<TEntity> left, Specification<TEntity> right)
    {
        return left.And(right);
    }

    /// <summary>
    /// Отрицание.
    /// </summary>
    public static Specification<TEntity> operator !(Specification<TEntity> current)
    {
        return current.Not();
    }

    #endregion
}