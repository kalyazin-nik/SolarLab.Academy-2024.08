using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.Infrastructure.Adverts.Specifications;

/// <summary>
/// Спецификация поиска объявлений не выше максимальной цены.
/// </summary>
/// <param name="maxPrice"></param>
public class MaxPriceSpecification(decimal maxPrice) : Specification<Advert>
{
    private readonly decimal _maxPrice = maxPrice;

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression => advert => advert.Price <= _maxPrice;
}
