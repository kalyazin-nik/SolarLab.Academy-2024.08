using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Сущности не были найдены.
/// </summary>
public class EntitiesNotFoundException : Exception, IApiException
{
    /// <inheritdoc />
    public ValidationResult ValidationResult { get; set; }

    /// <inheritdoc />
    public string Type => "https://tools.ietf.org/html/rfc9110#section-15.5.5";

    /// <inheritdoc />
    public string Title => "Запрашиваемые сущности не найдены.";

    /// <summary>
    /// Конструктор. Принимает объект результата проверки <see cref="FluentValidation.Results.ValidationResult"/>.
    /// </summary>
    /// <param name="validationResult">Результат выполнения проверки.</param>
    public EntitiesNotFoundException(ValidationResult validationResult) : base()
    {
        ValidationResult = validationResult;
    }

    /// <summary>
    /// Конструктор. Принимает название свойства и сообщение об ошибке, для последующего создания
    /// объекта результата проверки <see cref="FluentValidation.Results.ValidationResult"/>.
    /// </summary>
    /// <param name="propertyName">Название свойства.</param>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    public EntitiesNotFoundException(string propertyName, string errorMessage) : base()
    {
        ValidationResult = new ValidationResult { Errors = [new ValidationFailure(propertyName, errorMessage)] };
    }
}
