using System.Net;
using System.Text.Unicode;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Common;
using Newtonsoft.Json;

namespace SolarLab.Academy.Api.Middlewares;

/// <summary>
/// Промежуточное ПО для обработки ошибок.
/// </summary>
/// <param name="next">Делегат потока обрабатыващий HTTP-запрос.</param>
public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));
    private static readonly JsonSerializerSettings _jsonSettings = new() { NullValueHandling = NullValueHandling.Ignore };

    /// <summary>
    /// Вызывается для обработки исключений во время работы приложения.
    /// </summary>
    /// <param name="context">Контекст данных HTTP-запроса.</param>
    /// <param name="environment">Информация о среде окружения приложения.</param>
    /// <param name="serviceProvider">Объект предоставляющий пользовательскую поддержку другим объектам.</param>
    /// <returns>Задача, представляющая собой завершение обработки запроса.</returns>
    public async Task Invoke(HttpContext context, IHostEnvironment environment, IServiceProvider serviceProvider)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            var apiError = CreateApiError(exception, context, environment);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(apiError, _jsonSettings));
        }
    }

    private static ApiError CreateApiError(Exception exception, HttpContext context, IHostEnvironment environment)
    {
        var traceID = context.TraceIdentifier;
        var statusCode = GetStatusCode(exception);

        if (environment.IsDevelopment())
        {
            return new ApiError(exception.Message, exception.StackTrace ?? string.Empty, traceID, statusCode);
        }

        return exception switch
        {
            EntitiesNotFoundException ex => new HumanReadableError("Пользователи не были добавлены.", null!, traceID, statusCode, ex.HumanReadableMessage),
            EntityNotFoundException => new ApiError("Сущность не найдена.", null!, traceID, statusCode),
            _ => new ApiError("Произошла непредвиденная ошибка.", null!, traceID, statusCode)
        };
    }

    private static int GetStatusCode(Exception exception)
    {
        var statusCode =  exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            EntityNotFoundException => HttpStatusCode.NotFound,
            EntitiesNotFoundException => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError
        };

        return (int)statusCode;
    }
}
