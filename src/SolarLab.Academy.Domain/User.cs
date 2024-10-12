namespace SolarLab.Academy.Domain;

/// <summary>
/// Пользователь.
/// </summary>
public class User : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public override Guid Id { get; set; }

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
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreeatedAt { get; set; }
}
