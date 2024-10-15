using Microsoft.Extensions.Logging;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Validator;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Enums;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
/// <param name="categoryRepository">Репозиторий по работе с категорией.</param>
/// <param name="validationService">Сервис валидации объектов.</param>
/// <param name="logger">Логгер <see cref="CategoryService"/>.</param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class CategoryService(
    ICategoryRepository categoryRepository,
    IValidationService validationService,
    ILogger<CategoryService> logger,
    IStructuralLoggingService structuralLoggingService) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IValidationService _validationService = validationService;
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CategoryCreateDto createCategory, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("CreateCategory", createCategory, true);
        _logger.LogInformation("Создание объявления: {@createCategory}", createCategory);
        await _validationService.BeforExecuteRequestValidate_ExistEntityAsync(RepositoriesTypes.CategoryRpository, createCategory.ParentId, cancellationToken);

        return await _categoryRepository.CreateAsync(createCategory, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CategoryDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetCategoryById", id!);
        _logger.LogInformation("Получение категории по идентификатору: {@Id}", id);
        id = _validationService.BeforeExecuteRequestValidate_Id(id);
        var category = await _categoryRepository.GetByIdAsync(id.Value, cancellationToken);
        category = _validationService.AfterExecuteRequestValidate_Category(category);

        return category;
    }
}
