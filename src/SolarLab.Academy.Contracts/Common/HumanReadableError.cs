namespace SolarLab.Academy.Contracts.Common;

/// <summary>
/// Модель человеко-читаемой ошибки.
/// </summary>
public class HumanReadableError(string message, string description, string traceID, int code, string humanReadableErrorMessage) : ApiError(message, description, traceID, code)
{
    /// <summary>
    /// Человеко-читаемое сообщение об ошибке для пользователя.
    /// </summary>
    public string HumanReadableErrorMessage { get; } = humanReadableErrorMessage;
}
