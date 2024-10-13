﻿using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Validator.Service;

public class CategoryValidatorService(ICategoryRepository categoryRepository) : ICategoryValidatorService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    /// <inheritdoc />
    public CategoryDto AfterExecuteRequestValidate_Category(CategoryDto? category)
    {
        return category is not null ? category : throw new EntityNotFoundException("Response", "Категория не найдена.");
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
