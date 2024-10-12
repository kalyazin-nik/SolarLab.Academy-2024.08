namespace SolarLab.Academy.Contracts.Error;

/// <summary>
/// Интерфейс моделей обработанных ошбок.
/// </summary>
public interface IApiProcessedError : IApiError
{
    /// <summary>
    /// Тип ошибки.
    /// </summary>
    string? Type { get; set; }

    /// <summary>
    /// Заголовок.
    /// </summary>
    string? Title { get; set; }

    /// <summary>
    /// Статус код.
    /// </summary>
    int StatusCode { get; set; }

    /// <summary>
    /// Коллекция ошибок.
    /// </summary>
    IDictionary<string, string[]>? Errors { get; set; }

    /// <summary>
    /// Идентификатор следования запроса.
    /// </summary>
    string? TraceId { get; set; }
}
