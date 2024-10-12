namespace SolarLab.Academy.Domain;

/// <summary>
/// Объявление.
/// </summary>
public class Advert : EntityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public override Guid Id { get; set; }

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
    /// Является ли объявление отключенным.
    /// </summary>
    public bool Disabled { get; set; }

    /// <summary>
    /// Идентификатор категории.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Навигационное свойство категории.
    /// </summary>
    public virtual Category Category { get; set; } = null!;

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"Advert[ID:{Id} Name:{Name} CreatedAt:{CreatedAt}]";
    }
}
