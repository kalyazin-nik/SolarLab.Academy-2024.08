using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Adverts.Specifications;

namespace SolarLab.Academy.Infrastructure.Adverts.Builders;

/// <inheritdoc />
public class AdvertSpecificationBuilder : IAdvertSpecificationBuilder
{
    /// <inheritdoc />
    public ISpecification<Advert> Build(AdvertSearchRequestDto request)
    {
        var specification = Specification<Advert>.FromPredicate(x =>
            request.IncludeDisabled.GetValueOrDefault(false) || !x.Disabled);

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            specification = specification.And(new SearchStringSpecification(request.Search));
        }

        if (request.MinPrice.HasValue)
        {
            specification = specification.And(new MinPriceSpecification(request.MinPrice.Value));
        }

        if (request.MaxPrice.HasValue)
        {
            specification = specification.And(new MaxPriceSpecification(request.MaxPrice.Value));
        }

        return specification;
    }
}
