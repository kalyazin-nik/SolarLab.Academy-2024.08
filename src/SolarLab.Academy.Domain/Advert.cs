namespace SolarLab.Academy.Domain;

/// <summary>
/// Объявление.
/// </summary>
public class Advert(Guid id, string name, string description, Guid categoryID, DateTime createdAt) : EntityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; } = id;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; } = createdAt;

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; } = description;

    public bool IsDisabled { get; set; }

    public Guid CategoryID { get; set; } = categoryID;
    public virtual Category Category { get; set; }

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"Advert[ID:{Id} Name:{Name} CreatedAt:{CreatedAt}]";
    }
}
