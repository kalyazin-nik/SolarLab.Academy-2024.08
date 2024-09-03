namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Объект передачи данных запроса регистрации пользователя.
/// </summary>
public class UserRegisterRequestDto
{
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
    /// Возвращает строку, представляющую текущий объект.
    /// </summary>
    /// <returns>Строка, представляющая текущий объект.</returns>
    public override string ToString()
    {
        return $"{Name}. {Login}. BirthDate: {BirthDate}";
    }
}
