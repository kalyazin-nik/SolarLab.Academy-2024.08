namespace SolarLab.Academy.Contracts.Error;

/// <summary>
/// Модель ошибки для разработчика.
/// </summary>
public class DevelopmentError : IApiError
{
    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Идентификатор запроса.
    /// </summary>
    public string? TraceID { get; set; }

    /// <summary>
    /// Код ошбки.
    /// </summary>
    public int Code { get; set; }
}
