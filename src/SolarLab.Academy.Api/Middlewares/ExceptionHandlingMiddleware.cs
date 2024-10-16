using System.Net;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Serilog.Context;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Error;

namespace SolarLab.Academy.Api.Middlewares;

/// <summary>
/// Промежуточное ПО для обработки ошибок.
/// </summary>
/// <param name="next">Делегат потока обрабатыващий HTTP-запрос.</param>
public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private const string LogTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode}";
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));
    private static readonly JsonSerializerSettings _jsonSettings = new() { NullValueHandling = NullValueHandling.Ignore };

    /// <summary>
    /// Вызывается для обработки исключений во время работы приложения.
    /// </summary>
    /// <param name="context">Контекст данных HTTP-запроса.</param>
    /// <param name="environment">Информация о среде окружения приложения.</param>
    /// <param name="serviceProvider">Объект предоставляющий пользовательскую поддержку другим объектам.</param>
    /// <param name="logger">Логгер <see cref="ExceptionHandlingMiddleware"/></param>
    /// <returns>Задача, представляющая собой завершение обработки запроса.</returns>
    public async Task Invoke(HttpContext context, IHostEnvironment environment, IServiceProvider serviceProvider, ILogger<ExceptionHandlingMiddleware> logger)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var statusCode = GetStatusCode(exception);

            using (LogContext.PushProperty("Request.TraceId", context.TraceIdentifier))
            using (LogContext.PushProperty("Request.UserName", context.User.Identity?.Name ?? string.Empty))
            using (LogContext.PushProperty("Request.Connection", context.Connection.RemoteIpAddress?.ToString() ?? string.Empty))
            using (LogContext.PushProperty("Request.TraceId", context.Request.GetDisplayUrl()))
            {
                logger.LogError(exception, LogTemplate, context.Request.Method, context.Request.Path.ToString(), statusCode);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var apiError = CreateApiError(exception, context, environment);
            await context.Response.WriteAsync(JsonConvert.SerializeObject(apiError, _jsonSettings));
        }
    }

    private static IApiError CreateApiError(Exception exception, HttpContext context, IHostEnvironment environment)
    {
        var traceId = context.TraceIdentifier;
        var statusCode = GetStatusCode(exception);

        return exception switch
        {
            BadRequestException ex => GetErrorModel<BadRequestException, BadRequestError>(ex, statusCode, traceId),
            EntitiesNotFoundException ex => GetErrorModel<EntitiesNotFoundException, NotFoundError>(ex, statusCode, traceId),
            EntityNotFoundException ex => GetErrorModel<EntityNotFoundException, NotFoundError>(ex, statusCode, traceId),
            IdNotFoundException ex => GetErrorModel<IdNotFoundException, NotFoundError>(ex, statusCode,  traceId),
            UnauthorizedException ex => GetErrorModel<UnauthorizedException, UnauthorizedError>(ex, statusCode, traceId),
            _ => environment.IsDevelopment() ? new DevelopmentError
            {
                Message = exception.Message,
                Description = exception.StackTrace,
                Code = statusCode,
                TraceID = traceId
            } : new InternalServerError
            {
                Title = "Произошла непредвиденная ошибка.",
                Message = "Пожалуйста, сообщите о данной ошибке разработчику по электронной почте kalyazin.nik@yandex.ru или в телеграм @kalyazin_nik. " +
                    "В сообщении пришлите скрин экрана данной ошибки.",
                Route = string.Format($"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path.Value}{context.Request.QueryString.Value}"),
                Status = statusCode,
                TraceId = traceId
            }
        };
    }

    private static TError GetErrorModel<TException, TError>(TException exception, int statusCode, string? traceId)
        where TException : IApiException
        where TError : IApiProcessedError, new()
    {
        return new()
        {
            Type = exception.Type,
            Title = exception.Title,
            StatusCode = statusCode,
            Errors = exception.ValidationResult?.ToDictionary(),
            TraceId = traceId
        };
    }


    private static int GetStatusCode(Exception exception)
    {
        return (int)(exception switch
        {
            ArgumentException => HttpStatusCode.BadRequest,
            BadRequestException => HttpStatusCode.BadRequest,
            EntityNotFoundException => HttpStatusCode.NotFound,
            EntitiesNotFoundException => HttpStatusCode.NotFound,
            IdNotFoundException => HttpStatusCode.NotFound,
            UnauthorizedException => HttpStatusCode.Unauthorized,
            _ => HttpStatusCode.InternalServerError
        });
    }
}
