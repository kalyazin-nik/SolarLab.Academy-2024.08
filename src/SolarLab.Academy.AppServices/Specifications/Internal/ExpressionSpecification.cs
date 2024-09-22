using System.Linq.Expressions;

namespace SolarLab.Academy.AppServices.Specifications.Internal;

/// <summary>
/// Обобшенная спецификация на основе дерева выражений.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
/// <remarks>
/// Инициализирует экземпляр <see cref="ExpressionSpecification{TEntity}"/>.
/// </remarks>
internal class ExpressionSpecification<TEntity>(Expression<Func<TEntity, bool>> expression) : Specification<TEntity>
{
    /// <inheritdoc />
    public override Expression<Func<TEntity, bool>> PredicateExpression { get; } = expression ?? throw new ArgumentNullException(nameof(expression));
}