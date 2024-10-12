namespace SolarLab.Academy.Domain;

/// <summary>
/// Базовая сущность.
/// </summary>
public abstract class EntityBase 
{
    public abstract Guid Id { get; set; }
}
