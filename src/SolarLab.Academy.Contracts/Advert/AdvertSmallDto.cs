namespace SolarLab.Academy.Contracts.Advert;

/// <summary>
/// Сокращенный объект передачи данных объявления.
/// </summary>
public class AdvertSmallDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Включать в выборку отключенные объявления.
    /// </summary>
    public bool IncludeDisabled { get; set; }
}
