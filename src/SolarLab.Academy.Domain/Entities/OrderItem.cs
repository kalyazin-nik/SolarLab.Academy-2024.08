using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Domain.Entities;

/// <summary>
/// Позиция заказа. Товар.
/// </summary>
public sealed class OrderItem : BaseEntity
{
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Количество.
    /// </summary>
    public decimal Count { get; set; }

    /// <summary>
    /// Цена.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Идентификатор заказа.
    /// </summary>
    public Guid OrderID { get; set; }

    /// <summary>
    /// Заказ.
    /// </summary>
    public Order Order { get; set; } = null!;

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"{Name}. Count: {Count}. Price: {Price}. OrderID: {OrderID}";
    }
}
