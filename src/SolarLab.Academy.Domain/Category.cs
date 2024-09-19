namespace SolarLab.Academy.Domain;

/// <summary>
/// Категория.
/// </summary>
public class Category(Guid id, Guid? parentID, string name, DateTime createdAt) : EntityBase
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
    /// Родительская категория.
    /// </summary>
    public Guid? ParentID { get; set; } = parentID;

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = name;

    public virtual List<Advert> Adverts { get; set; }

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"Category[ID:{Id} ParentID:{ParentID} Name:{Name} CreatedAt:{CreatedAt}]";
    }
}
