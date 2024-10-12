namespace SolarLab.Academy.Contracts.Error;

/// <summary>
/// Модель ошибки неверного запроса.
/// </summary>
public class BadRequestError : IApiProcessedError
{
    /// <inheritdoc />
    public string? Type { get; set; }

    /// <inheritdoc />
    public string? Title { get; set; }

    /// <inheritdoc />
    public int StatusCode { get; set; }

    /// <inheritdoc />
    public IDictionary<string, string[]>? Errors { get; set; }

    /// <inheritdoc />
    public string? TraceId { get; set; }
}
