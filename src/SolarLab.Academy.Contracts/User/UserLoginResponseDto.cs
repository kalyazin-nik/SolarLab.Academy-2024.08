namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Объект передачи данных ответа входа пользователя в систему.
/// </summary>
public class UserLoginResponseDto
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
}
