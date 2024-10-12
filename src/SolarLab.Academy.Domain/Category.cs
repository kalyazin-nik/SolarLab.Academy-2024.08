namespace SolarLab.Academy.Domain;

/// <summary>
/// Категория.
/// </summary>
public class Category : EntityBase
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

    public virtual List<Advert> Adverts { get; set; }

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"Category[ID:{Id} ParentID:{ParentId ?? null} Name:{Name} CreatedAt:{CreatedAt}]";
    }
}
