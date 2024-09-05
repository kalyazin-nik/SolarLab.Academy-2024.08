namespace SolarLab.Academy.AppServices.Exceptions;

/// <summary>
/// Исключение. Сущность не была найдена.
/// </summary>
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() : base("Сущность не была найдена.") { }
}
