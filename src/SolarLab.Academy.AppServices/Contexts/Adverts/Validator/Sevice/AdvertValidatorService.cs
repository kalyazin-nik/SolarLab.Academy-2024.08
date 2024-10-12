using FluentValidation.Results;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Exceptions;
using System.Threading;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;

public class AdvertValidatorService(IAdvertRepository advertRepository, ICategoryRepository categoryRepository) : IAdvertValidatorService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    private readonly string _advertId = "id";
    private readonly string _categoryId = "categoryId";
    private readonly string _nullError = "Поле '{0}' не может быть пустым.";
    private readonly string _emptyError = "Поле '{0}' не может иметь вид по умолчанию '{1}'.";
    private readonly string _advertNotFoundError = "Объявление не найдено.";
    private readonly string _categoryNotFoundError = "Категория не найдена.";

    public async Task ValidateCategoryIdForAdvertAsync(Guid? id, CancellationToken cancellationToken)
    {
        await ValidateId(id, _categoryId, _nullError, _emptyError, _categoryNotFoundError, cancellationToken);
    }

    public async Task ValidateIdForAdvertAsync(Guid? id, CancellationToken cancellationToken)
    {
        await ValidateId(id, _advertId, _nullError, _emptyError, _advertNotFoundError, cancellationToken);
    }

    private async Task ValidateId(Guid? id, string propertyName, string nullError, string emptyError, string notFoundError,  CancellationToken cancellationToken)
    {
        if (id.HasValue)
        {
            if (id.Value == Guid.Empty)
            {
                ThrowBadRequestException(propertyName, string.Format(emptyError, propertyName, Guid.Empty));
            }
            else if (await _categoryRepository.GetByIdAsync(id.Value, cancellationToken) is null)
            {
                ThrowIdNotFoundException(propertyName, notFoundError);
            }
        }
        else
        {
            ThrowBadRequestException(propertyName, string.Format(nullError, propertyName));
        }
    }

    private static void ThrowBadRequestException(string propertyName, string errorMessage)
    {
        var error = new ValidationResult { Errors = [new ValidationFailure(propertyName, errorMessage)] };
        throw new BadRequestException(error);
    }
    private static void ThrowIdNotFoundException(string propertyName, string errorMessage)
    {
        var error = new ValidationResult { Errors = [new ValidationFailure(propertyName, errorMessage)] };
        throw new IdNotFoundException(error);
    }
}
