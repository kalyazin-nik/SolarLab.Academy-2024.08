﻿using FluentValidation.Results;

namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Сущность не была найдена.
/// </summary>
/// <param name="validationResult">Резальтат выполнения валидации.</param>
public class EntityNotFoundException(ValidationResult validationResult) : Exception(), IApiException
{
    /// <inheritdoc />
    public ValidationResult ValidationResult { get; set; } = validationResult;

    /// <inheritdoc />
    public string Type => "https://tools.ietf.org/html/rfc9110#section-15.5.5";

    /// <inheritdoc />
    public string Title => "Запрашиваемая сущность не найдена.";
}
