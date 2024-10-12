using System.ComponentModel.DataAnnotations;

namespace SolarLab.Academy.Contracts.User;

/// <summary>
/// Объект передачи данных запроса регистрации пользователя.
/// </summary>
public class UserRegisterRequestDto : IValidatableObject
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

    /// <summary>
    /// Определяет, является ли указанный объект допустимым.
    /// </summary>
    /// <param name="validationContext">Контекст проверки.</param>
    /// <returns>Коллекция, содержащая информацию о неудачной проверке.</returns>
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (GetValidationResultOfBirthDate() is ValidationResult birthDateValidationResult)
        {
            yield return birthDateValidationResult;
        }
    }

    private ValidationResult? GetValidationResultOfBirthDate()
    {
        const byte maxAge = 100;
        const byte minAge = 18;

        if (BirthDate == DateTime.MinValue)
        {
            return new ValidationResult("Значение даты рождения не может быть по умолчанию!");
        }
        if (BirthDate <= DateTime.Now.AddYears(-maxAge))
        {
            return new ValidationResult($"Пользователю, возраст которого превышает {maxAge} лет, зарегистрироваться не удастся!");
        }
        if (BirthDate >= DateTime.Now.AddYears(-minAge))
        {
            return new ValidationResult($"Пользователю, возраст которого меньше {minAge} лет, зарегистрироваться не удастся!");
        }

        return null;
    }
}
