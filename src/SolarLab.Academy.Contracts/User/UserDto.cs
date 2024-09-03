namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Объект передачи данных пользователя.
/// </summary>
public sealed class UserDto
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid ID { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// День рождения.
    /// </summary>
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Электронная почта.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"{Name}. {Login}. BirthDate: {BirthDate}";
    }
}
