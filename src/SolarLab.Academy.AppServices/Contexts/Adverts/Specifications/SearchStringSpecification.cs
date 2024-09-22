using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain;
using System.Linq.Expressions;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Specifications;

/// <summary>
/// Спецификация поиска объявлений по поисковой строке.
/// </summary>
/// <param name="searchString"></param>
public class SearchStringSpecification(string searchString) : Specification<Advert>
{
    private readonly string _searchString = searchString;

    /// <inheritdoc />
    public override Expression<Func<Advert, bool>> PredicateExpression => 
        advert => 
            advert.Name.ToLower().Contains(_searchString.ToLower()) ||
            advert.Description.ToLower().Contains(_searchString.ToLower());
}
