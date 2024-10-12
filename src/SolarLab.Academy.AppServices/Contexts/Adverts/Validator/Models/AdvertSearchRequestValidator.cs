using FluentValidation;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Models;

public class AdvertSearchRequestValidator : AbstractValidator<AdvertSearchRequestDto>
{
    public AdvertSearchRequestValidator()
    {
        RuleFor(x => x.MinPrice)
            .LessThanOrEqualTo(x => x.MaxPrice).WithMessage("Минимальная цена не должна превышать максимальную.");

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(x => x.MinPrice).WithMessage("Минимальная цена не должна превышать максимальную.");

        RuleFor(x => x.Take)
            .NotNull().WithMessage("Поле 'take' обязательно.")
            .GreaterThan(0).WithMessage("Поле 'take' должно быть больше нуля.");
    }
}
