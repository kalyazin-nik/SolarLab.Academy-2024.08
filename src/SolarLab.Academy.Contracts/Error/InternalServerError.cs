namespace SolarLab.Academy.Contracts.Error;

/// <summary>
/// Модель ошбики сервера.
/// </summary>
public class InternalServerError : IApiError
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Сообщение.
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Маршрут запроса.
    /// </summary>
    public string Route { get; set; } = null!;

    /// <summary>
    /// Идентификатор следования запроса.
    /// </summary>
    public string TraceId { get; set; } = null!;

    /// <summary>
    /// Статус код.
    /// </summary>
    public int Status { get; set; }
}
