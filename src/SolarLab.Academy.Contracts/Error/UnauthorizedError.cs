
namespace SolarLab.Academy.Contracts.Error;

/// <summary>
/// Модель ошибки авторизации.
/// </summary>
public class UnauthorizedError : IApiProcessedError
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
