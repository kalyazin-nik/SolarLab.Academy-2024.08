using SolarLab.Academy.Contracts.Enums;

namespace SolarLab.Academy.Contracts.Order;

/// <summary>
/// Объект передачи данных заказа.
/// </summary>
public sealed class OrderDto
{
    /// <summary>
    /// Идентификатор заказа.
    /// </summary>
    public Guid ID { get; set; }

    /// <summary>
    /// Описание заказа.
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// Комментарий к заказу.
    /// </summary>
    public string Comment { get; set; } = null!;

    /// <summary>
    /// Сумма заказа.
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Общее количество товаров.
    /// </summary>
    public decimal TotalCount { get; set; }

    /// <summary>
    /// Статус заказа.
    /// </summary>
    public OrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserID { get; set; }

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"{Description}. Amount: {Amount}. TotalCount: {TotalCount}. OrderStatus: {OrderStatus}";
    }
}
