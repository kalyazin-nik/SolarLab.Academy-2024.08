using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Сущности не были найдены.
/// </summary>
/// <param name="validationResult">Резальтат выполнения валидации.</param>
public class EntitiesNotFoundException(ValidationResult validationResult) : Exception(), IApiException
{
    /// <inheritdoc />
    public ValidationResult ValidationResult { get; set; } = validationResult;

    /// <inheritdoc />
    public string Type => "https://tools.ietf.org/html/rfc9110#section-15.5.5";

    /// <inheritdoc />
    public string Title => "Запрашиваемые сущности не найдены.";
}
