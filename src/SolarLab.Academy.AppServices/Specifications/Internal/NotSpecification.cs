using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications.Extensions;

namespace SolarLab.Academy.AppServices.Specifications.Internal;

/// <summary>
/// Спецификация логического отрицания.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
internal class NotSpecification<TEntity> : Specification<TEntity>
{
    /// <inheritdoc />
    public override Expression<Func<TEntity, bool>> PredicateExpression { get; }

    /// <summary>
    /// Инициализирует экземпляр <see cref="NotSpecification{TEntity}"/>.
    /// </summary>
    public NotSpecification(ISpecification<TEntity> specification)
    {
        ArgumentNullException.ThrowIfNull(specification);

        PredicateExpression = specification.PredicateExpression.Not();
    }
}