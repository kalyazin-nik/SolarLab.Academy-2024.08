using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Интерфейс исключений.
/// </summary>
public interface IApiException
{
    /// <summary>
    /// Результат выполенения валидации.
    /// </summary>
    ValidationResult ValidationResult { get; }

    /// <summary>
    /// Тип ошибки.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; }
}
