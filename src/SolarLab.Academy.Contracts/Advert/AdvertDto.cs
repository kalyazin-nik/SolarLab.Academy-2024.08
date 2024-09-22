namespace SolarLab.Academy.Contracts.Advert;

/// <summary>
/// Объект передачи данных объявления.
/// </summary>
public class AdvertDto
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
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Включать в выборку отключенные объявления.
    /// </summary>
    public bool IncludeDisabled { get; set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryID { get; set; }
}
