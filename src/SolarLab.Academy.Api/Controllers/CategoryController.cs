using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.Contracts.Categories;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с категорией.
/// </summary>
/// <param name="categoryService">Сервис по работе с категорией.</param>
[Authorize]
[ApiController]
[Route("category")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        var categoryId = await _categoryService.AddAsync(dto, cancellationToken);

        return StatusCode((int)HttpStatusCode.Created, categoryId);
    }

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных категории, если категория будет найдена, иначе null.</returns>
    [HttpGet("get")]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var categoryDto = await _categoryService.GetByIdAsync(id, cancellationToken);

        return categoryDto is not null ? Ok(categoryDto) : NoContent();
    }
}
