namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Модель запроса входа пользователя в систему.
/// </summary>
public class UserLoginRequestDto
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; } = null!;
}
