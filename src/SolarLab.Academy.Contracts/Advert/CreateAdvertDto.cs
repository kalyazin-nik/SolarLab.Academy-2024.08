namespace SolarLab.Academy.Contracts.Advert;

/// <summary>
/// Объект передачи данных объявления.
/// </summary>
public class CreateAdvertDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryID { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }
}
