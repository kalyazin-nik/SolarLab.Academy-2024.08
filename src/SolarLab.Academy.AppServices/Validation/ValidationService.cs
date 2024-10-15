using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;
using SolarLab.Academy.AppServices.Contexts.FileContent.Validator;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Enums;

namespace SolarLab.Academy.AppServices.Validator;

public class ValidationService(
    ICategoryRepository categoryRepository,
    IAdvertRepository advertRepository,
    IFileContentRepository fileContentRepository,
    IUserRepository userRepository) : IValidationService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IAdvertRepository _advertRepository = advertRepository;
    private readonly IFileContentRepository _fileContentRepository = fileContentRepository;
    private readonly IUserRepository _userRepository = userRepository;

    /// <inheritdoc />
    public IReadOnlyCollection<AdvertSmallDto> AfterExecuteRequestValidate_AdvertSmallCollection(IReadOnlyCollection<AdvertSmallDto>? collection)
    {
        return collection is not null && collection.Count > 0 ? collection : throw new EntitiesNotFoundException("Response", "Объявления не найдены.");
    }

    /// <inheritdoc />
    public AdvertDto AfterExecuteRequestValidate_Advert(AdvertDto? advert)
    {
        return advert is not null ? advert : throw new EntityNotFoundException("Response", "Объявление на найдено.");
    }

    /// <inheritdoc />
    public CategoryDto AfterExecuteRequestValidate_Category(CategoryDto? category)
    {
        return category is not null ? category : throw new EntityNotFoundException("Response", "Категория не найдена.");
    }

    /// <inheritdoc />
    public async Task<IFormFile> BeforeExecuteRequestValidate_IFormFileAsync(IFormFile? file, CancellationToken cancellationToken)
    {
        if (await new FormFileValidator().ValidateAsync(file!, cancellationToken) is ValidationResult result && !result.IsValid)
        {
            throw new BadRequestException(result);
        }

        return file!;
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
    public async Task<Guid> BeforExecuteRequestValidate_ExistEntityAsync(RepositoriesTypes repositoryType, Guid? id, CancellationToken cancellationToken)
    {
        id = BeforeExecuteRequestValidate_Id(id);
        var repository = GetRepository(repositoryType);
        if (await repository.IsExistAsync(id.Value, cancellationToken))
        {
            return id.Value;
        }

        throw new EntityNotFoundException("Id", $"{GetEntityNameLinkedToRepository(repositoryType)} с таким идентификатором не существует.");
    }

    private IBaseRepository GetRepository(RepositoriesTypes repositoryType)
    {
        return repositoryType switch
        {
            RepositoriesTypes.UserRepository => _userRepository,
            RepositoriesTypes.CategoryRpository => _categoryRepository,
            RepositoriesTypes.AdvertRpository => _advertRepository,
            RepositoriesTypes.FileRepository => _fileContentRepository,
            _ => throw new NotImplementedException()
        };
    }

    private static string GetEntityNameLinkedToRepository(RepositoriesTypes repositoryType)
    {
        return repositoryType switch
        {
            RepositoriesTypes.UserRepository => "Пользователь",
            RepositoriesTypes.CategoryRpository => "Категория",
            RepositoriesTypes.AdvertRpository => "Объявление",
            RepositoriesTypes.FileRepository => "Файл",
            _ => throw new NotImplementedException()
        };
    }
}
