namespace SolarLab.Academy.Contracts.Categories;

/// <summary>
/// Объект передачи данных категории.
/// </summary>
public class CategoryDto
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
    /// Родительская категория.
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Наименование.
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
