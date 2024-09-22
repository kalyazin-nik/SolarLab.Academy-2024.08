using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Builders;

/// <summary>
/// Строит спецификации для объявлений.
/// </summary>
public interface IAdvertSpecificationBuilder
{
    /// <summary>
    /// Строит спецификацию по запросу.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <returns>Спецификация.</returns>
    ISpecification<Advert> Build(SearchRequestAdvertDto request);
}
