using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Неверный запрос.
/// </summary>
public class BadRequestException : Exception, IApiException
{
    /// <inheritdoc />
    public ValidationResult ValidationResult { get; }

    /// <inheritdoc />
    public string Type => "https://tools.ietf.org/html/rfc9110#section-15.5.1";

    /// <inheritdoc />
    public string Title => "Произошла одна или несколько ошибок проверки.";

    /// <summary>
    /// Конструктор. Принимает объект результата проверки <see cref="FluentValidation.Results.ValidationResult"/>.
    /// </summary>
    /// <param name="validationResult">Результат выполнения проверки.</param>
    public BadRequestException(ValidationResult validationResult) : base()
    {
        ValidationResult = validationResult;
    }

    /// <summary>
    /// Конструктор. Принимает название свойства и сообщение об ошибке, для последующего создания
    /// объекта результата проверки <see cref="FluentValidation.Results.ValidationResult"/>.
    /// </summary>
    /// <param name="propertyName">Название свойства.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    public BadRequestException(string propertyName, string errorMessage) : base()
    {
        ValidationResult = new ValidationResult { Errors = [new ValidationFailure(propertyName, errorMessage)] };
    }
}
