using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications.Extensions;

namespace SolarLab.Academy.AppServices.Specifications.Internal;

/// <summary>
/// Спецификация "ИЛИ".
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
internal class OrSpecification<TEntity> : Specification<TEntity>
{
    /// <inheritdoc />
    public override Expression<Func<TEntity, bool>> PredicateExpression { get; }

    /// <summary>
    /// Инициализирует экземпляр спецификации <see cref="OrSpecification{TEntity}"/>.
    /// </summary>
    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
    {
        ArgumentNullException.ThrowIfNull(right);
        ArgumentNullException.ThrowIfNull(left);

        PredicateExpression = left.PredicateExpression.Or(right.PredicateExpression);
    }
}