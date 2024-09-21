namespace SolarLab.Academy.Domain;

/// <summary>
/// Категория.
/// </summary>
public class Category : EntityBase
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
    public Guid? ParentID { get; set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; }

    public virtual List<Advert> Adverts { get; set; }

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"Category[ID:{Id} ParentID:{ParentID ?? null} Name:{Name} CreatedAt:{CreatedAt}]";
    }
}
