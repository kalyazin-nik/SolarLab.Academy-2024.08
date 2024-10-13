using System.Net;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Error;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с категорией.
/// </summary>
/// <param name="categoryService">Сервис по работе с категорией.</param>
/// <param name="logger">Логгер <see cref="CategoryController"/></param>
// [Authorize]
[ApiController]
[Route("category")]
[ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
public class CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly ILogger<CategoryController> _logger = logger;

    /// <summary>
    /// Создание категории.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор созданной категории.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CategoryCreateDto dto, CancellationToken cancellationToken)
    {
        return StatusCode((int)HttpStatusCode.Created, await _categoryService.AddAsync(dto, cancellationToken));
    }

    /// <summary>
    /// Получение категории по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных категории, если категория будет найдена, иначе null.</returns>
    [HttpGet("get")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _categoryService.GetByIdAsync(id, cancellationToken));
    }
}
