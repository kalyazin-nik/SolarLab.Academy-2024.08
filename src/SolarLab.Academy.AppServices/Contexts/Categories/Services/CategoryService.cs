using Microsoft.Extensions.Logging;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Contexts.Categories.Validator.Service;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.AppServices.Contexts.Categories.Services;

/// <summary>
/// Сервис по работе с категорией.
/// </summary>
/// <param name="categoryRepository">Репозиторий по работе с категорией.</param>
/// <param name="categoryValidatorService">Сервис валидации объектов.</param>
/// <param name="logger">Логгер <see cref="CategoryService"/>.</param>
/// <param name="structuralLoggingService">Служба структурного логгирования.</param>
public class CategoryService(
    ICategoryRepository categoryRepository,
    ICategoryValidatorService categoryValidatorService,
    ILogger<CategoryService> logger,
    IStructuralLoggingService structuralLoggingService) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly ICategoryValidatorService _categoryValidatorService = categoryValidatorService;
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly IStructuralLoggingService _structuralLoggingService = structuralLoggingService;

    /// <inheritdoc />
    public async Task<Guid> AddAsync(CategoryCreateDto createCategory, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("CreateCategory", createCategory, true);
        _logger.LogInformation("Создание объявления: {@createCategory}", createCategory);

        if (createCategory.ParentId.HasValue)
        {
            await _categoryValidatorService.BeforExecuteRequestValidate_ExistCategoryAsync(createCategory.ParentId, cancellationToken);
        }

        return await _categoryRepository.CreateAsync(createCategory, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CategoryDto> GetByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        using var _ = _structuralLoggingService.PushProperty("GetCategoryById", id!);
        _logger.LogInformation("Получение категории по идентификатору: {@Id}", id);
        id = _categoryValidatorService.BeforeExecuteRequestValidate_Id(id);
        var category = await _categoryRepository.GetByIdAsync(id.Value, cancellationToken);
        category = _categoryValidatorService.AfterExecuteRequestValidate_Category(category);

        return category;
    }
}
