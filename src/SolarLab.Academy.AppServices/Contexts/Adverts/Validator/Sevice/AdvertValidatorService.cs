using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;

public class AdvertValidatorService(ICategoryRepository categoryRepository) : IAdvertValidatorService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    /// <inheritdoc />
    public IReadOnlyCollection<AdvertSmallDto> AfterExecuteRequestValidate_Collection(IReadOnlyCollection<AdvertSmallDto>? collection)
    {
        return collection is not null && collection.Count > 0 ? collection : throw new EntitiesNotFoundException("Response", "Объявления не найдены.");
    }

    /// <inheritdoc />
    public AdvertDto AfterExecuteRequestValidate_Advert(AdvertDto? advert)
    {
        return advert is not null ? advert : throw new EntityNotFoundException("Response", "Объявление на найдено.");
    }

    /// <inheritdoc />
    public Guid BeforeExecuteRequestValidate_Id(Guid? id)
    {
        var propertyName = "Id";

        if (id.HasValue)
        {
            return id.Value != Guid.Empty ? id.Value : throw new BadRequestException(propertyName, $"Поле '{propertyName}' не может иметь вид по умолчанию '{Guid.Empty}'.");
        }
        else
        {
            throw new BadRequestException(propertyName, $"Поле '{propertyName}' не может быть пустым.");
        }
    }

    /// <inheritdoc />
    public async Task<bool> BeforExecuteRequestValidate_ExistCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        id = BeforeExecuteRequestValidate_Id(id);
        if (await _categoryRepository.GetByIdAsync(id.Value, cancellationToken) is not null)
        {
            return true;
        }

        throw new EntityNotFoundException("CategoryId", "Категория не существует.");
    }
}
