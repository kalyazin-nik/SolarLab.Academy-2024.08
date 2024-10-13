using FluentValidation;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Validator.Models;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateDto>
{
    private const string Required = "Поле '{0}' обязательно.";
    private const string NotEmpty = "{0} не может быть пустым.";
    private const string MaxLength = "Длина '{0}' не должна превышать {1} символов. Текущая длина {2} символов.";
    private const int NameMaxLength = 100;
    private const int DescriptionMaxLength = 5000;
    private const int NumberMaxLength = 100;

    public CategoryCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage(x => string.Format(Required, nameof(x.Name)))
            .NotEmpty().WithMessage(x => string.Format(NotEmpty, nameof(x.Name)))
            .MaximumLength(NameMaxLength).WithMessage(x => string.Format(MaxLength, nameof(x.Name), NameMaxLength, x.Name!.Length));

        RuleFor(x => x.Description)
            .NotNull().WithMessage(x => string.Format(Required, nameof(x.Description)))
            .NotEmpty().WithMessage(x => string.Format(NotEmpty, nameof(x.Description)))
            .MaximumLength(DescriptionMaxLength).WithMessage(x => string.Format(MaxLength, nameof(x.Description), DescriptionMaxLength, x.Description!.Length));

        RuleFor(x => x.Number)
            .NotNull().WithMessage(x => string.Format(Required, nameof(x.Number)))
            .NotEmpty().WithMessage(x => string.Format(NotEmpty, nameof(x.Number)))
            .MaximumLength(NumberMaxLength).WithMessage(x => string.Format(MaxLength, nameof(x.Number), NumberMaxLength, x.Number!.Length));
    }
}
