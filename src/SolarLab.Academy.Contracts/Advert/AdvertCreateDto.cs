namespace SolarLab.Academy.Contracts.Advert;

/// <summary>
/// Объект передачи данных объявления.
/// </summary>
public class AdvertCreateDto
{
    /// <summary>
    /// Наименование.
    /// </summary>
    // [Required]
    public string? Name { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    // [Required]
    public string? Description { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    // [Required]
    public decimal? Price { get; set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    // [Required]
    // [CategoryValidation]
    public Guid? CategoryId { get; set; }
}
