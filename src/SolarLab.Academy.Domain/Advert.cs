namespace SolarLab.Academy.Domain;

/// <summary>
/// Объявление.
/// </summary>
public class Advert : EntityBase
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
    public string Name { get; set; }

    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; set; }

    public bool IsDisabled { get; set; }

    public Guid CategoryID { get; set; }
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
