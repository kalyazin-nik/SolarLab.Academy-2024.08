using FluentValidation;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Models;

public class AdvertSearchRequestValidator : AbstractValidator<AdvertSearchRequestDto>
{
    public AdvertSearchRequestValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Поле 'MinPrice' должно быть больше или равно нулю.")
            .LessThanOrEqualTo(x => x.MaxPrice).WithMessage("Минимальная цена не должна превышать максимальную.");

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Поле 'MaxPrice' должно быть больше или равно нулю.")
            .GreaterThanOrEqualTo(x => x.MinPrice).WithMessage("Максимальная цена не должна быть меньше минимальной.");

        RuleFor(x => x.Take)
            .NotNull().WithMessage("Поле 'Take' обязательно.")
            .GreaterThan(0).WithMessage("Поле 'take' должно быть больше нуля.");
    }
}
