using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Неверный запрос.
/// </summary>
/// <param name="validationResult">Результат выполнения валидации.</param>
public class BadRequestException(ValidationResult validationResult) : Exception(), IApiException
{
    /// <inheritdoc />
    public ValidationResult ValidationResult { get; } = validationResult;

    /// <inheritdoc />
    public string Type => "https://tools.ietf.org/html/rfc9110#section-15.5.1";

    /// <inheritdoc />
    public string Title => "Произошла одна или несколько ошибок проверки.";
}
