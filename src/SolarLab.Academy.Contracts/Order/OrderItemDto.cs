namespace SolarLab.Academy.Contracts.Order;

/// <summary>
/// Объкет передачи данных позиции заказа.
/// </summary>
public sealed class OrderItemDto
{
    /// <summary>
    /// Идентификатор позиции заказа.
    /// </summary>
    public Guid ID { get; set; }

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

    public override string ToString()
    {
        return $"{Name}. Count: {Count}. Price: {Price}. OrderID: {OrderID}";
    }
}
