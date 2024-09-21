namespace SolarLab.Academy.Contracts.Categories;

/// <summary>
/// Объект передачи данных создания категории.
/// </summary>
public class CategoryCreateDto
{
    /// <summary>
    /// Название категории.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Номер.
    /// </summary>
    public string Number { get; set; }
}
