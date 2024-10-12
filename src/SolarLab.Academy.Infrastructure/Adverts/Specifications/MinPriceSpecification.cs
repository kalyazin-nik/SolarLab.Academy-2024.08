using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Infrastructure.Adverts.Specifications;

/// <summary>
/// Спецификация поиска объявлений не ниже минимальной цены.
/// </summary>
/// <param name="minPrice">Минимальная цена.</param>
public class MinPriceSpecification(decimal minPrice) : Specification<Advert>
{
    private readonly decimal _minPrice = minPrice;

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression => advert => advert.Price >= _minPrice;
}
