using System.ComponentModel.DataAnnotations;

namespace SolarLab.Academy.Contracts.Advert.Attributes;

/// <summary>
/// Указывает, что требуется проверить значение идентификатора категории.
/// </summary>
public class CategoryValidationAttribute : ValidationAttribute
{
    private const string WarningCategoryIdIsEmpty = "Идентификатор категории не может быть пустым!";
    private const string WarningCategoryIdIsNotGuidType = "Идентификатор категории имеет тип данных отличный от Guid!";

    /// <summary>
    /// Проверяет идентификатор категории.
    /// </summary>
    /// <param name="value">Объект для проверки.</param>
    /// <param name="validationContext">Объект, <see cref="ValidationContext"/>, описывающий контекст, 
    /// в котором выполняются проверки достоверности. Этот параметр не может иметь значения null.</param>
    /// <returns>Экземпляр класса <see cref="ValidationResult"/>, допускающий значение null.</returns>
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                return new ValidationResult(WarningCategoryIdIsEmpty);
            }
        }
        else
        {
            return new ValidationResult(WarningCategoryIdIsNotGuidType);
        }

        return base.IsValid(value, validationContext);
    }
}
