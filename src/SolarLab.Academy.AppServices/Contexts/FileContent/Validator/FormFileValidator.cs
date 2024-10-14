using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace SolarLab.Academy.AppServices.Contexts.FileContent.Validator;

public class FormFileValidator : AbstractValidator<IFormFile>
{
    private static readonly HashSet<string> _formats = ["image/jpeg", "image/jpg", "image/png"];

    public FormFileValidator()
    {
        RuleFor(x => x)
            .NotNull().WithMessage("Файл не должен быть пустым.");

        RuleFor(x => x.ContentType)
            .NotNull().WithMessage(x => $"Поле '{nameof(x.ContentType)}' обязательлно к заполнению.")
            .Must(_formats.Contains).WithMessage(x => $"Формат файла '{x.ContentType}' является недопустимым");

        RuleFor(x => x.Length).GreaterThan(0).WithMessage("Размер файла должен быть больше '0 byte'.")
            .LessThanOrEqualTo(2097152).WithMessage(x => $"Размер файла не должен превышать '2 МВ'. Текущий размер загружаемого файла - '{Math.Round(x.Length / 1048576.0, 2)} МВ'.");
    }
}
