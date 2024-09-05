namespace SolarLab.Academy.Contracts.Common;

/// <summary>
/// Модель ошибки.
/// </summary>
public class ApiError(string message, string description, string traceID, int code)
{
    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    public string Message { get; set; } = message;

    /// <summary>
    /// Описание ошибки.
    /// </summary>
    public string Description { get; set; } = description;

    /// <summary>
    /// Идентификатор запроса.
    /// </summary>
    public string TraceID { get; set; } = traceID;

    /// <summary>
    /// Код ошбки.
    /// </summary>
    public int Code { get; set; } = code;
}
