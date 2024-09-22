using System.Linq.Expressions;

namespace SolarLab.Academy.AppServices.Specifications.Extensions;

/// <summary>
/// Набор расширений для <see cref="Expression{TDelegate}"/>.
/// </summary>
public static class ExpressionExtensions
{
    /// <summary>
    /// Выполняет композицию выражений.
    /// </summary>
    /// <param name="left">Первое выражение.</param>
    /// <param name="right">Правое выражение.</param>
    /// <param name="compose">Операция композиции.</param>
    /// <typeparam name="TDelegate">Тип делегата.</typeparam>
    /// <returns>Скомпонованное выражение.</returns>
    public static Expression<TDelegate> Compose<TDelegate>(this Expression<TDelegate> left, Expression<TDelegate> right, Func<Expression, Expression, Expression> compose)
    {
        var rightBody = ParameterRebinderExpressionVisitor.RebindParameters(left, right);

        return Expression.Lambda<TDelegate>(compose(left.Body, rightBody), left.Parameters);
    }
}