using FluentValidation;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Models;

public class AdvertCreateValidator : AbstractValidator<AdvertCreateDto>
{
    private const string Required = "Поле '{0}' обязательно.";
    private const string NotEmpty = "{0} не может быть пустым.";

    public AdvertCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage(string.Format(Required, "name"))
            .NotEmpty().WithMessage(string.Format(NotEmpty, "Название"));

        RuleFor(x => x.Description)
            .NotNull().WithMessage(string.Format(Required, "description"))
            .NotEmpty().WithMessage(string.Format(NotEmpty, "Описание"));

        RuleFor(x => x.Price)
            .NotNull().WithMessage(string.Format(Required, "price"))
            .GreaterThan(10M).WithMessage("Цена должна быть больше 10.");

        RuleFor(x => x.CategoryId)
            .NotNull().WithMessage(string.Format(Required, "categoryId"))
            .NotEqual(Guid.Empty).WithMessage("Поле 'categoryId' не должно быть равным по умолчанию: {00000000-0000-0000-0000-000000000000}");
    }
}
