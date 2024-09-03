using SolarLab.Academy.Contracts.Enums;
using SolarLab.Academy.Domain.Base;

namespace SolarLab.Academy.Domain.Entities;

/// <summary>
/// Заказ.
/// </summary>
public sealed class Order : BaseEntity
{
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
    /// Пользователь.
    /// </summary>
    public User User { get; set; } = null!;

    /// <summary>
    /// Позиции заказа.
    /// </summary>
    public ICollection<OrderItem> Items { get; set; } = null!;

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"{Description}. Amount: {Amount}. TotalCount: {TotalCount}. OrderStatus: {OrderStatus}";
    }
}
