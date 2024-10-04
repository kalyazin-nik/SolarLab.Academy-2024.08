using System.Net;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.Contracts.Advert;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с объявлениями.
/// </summary>
/// <param name="advertService">Сервис по работе с объявлениями.</param>
/// <param name="logger">Логгер <see cref="AdvertController"/></param>
[ApiController]
[Route("advert")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class AdvertController(IAdvertService advertService, ILogger<AdvertController> logger) : ControllerBase
{
    private readonly IAdvertService _advertService = advertService;
    private readonly ILogger<AdvertController> _logger = logger;

    /// <summary>
    /// Создание обяевления.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор объявления.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Создание объявления: {@Dto}", dto);
        var advertId = await _advertService.AddAsync(dto, cancellationToken);

        return StatusCode((int)HttpStatusCode.Created, advertId);
    }

    /// <summary>
    /// Получение коллекции объявлений по идентификатору категории.
    /// </summary>
    /// <param name="categoryId">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объектов передачи данных объявлений в сокращенном виде.</returns>
    [HttpGet("get-by-category-id")]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvertDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Поиск объявлений по идентификатору категории: {@CategoryId}", categoryId);
        var shortAdvertDtos = await _advertService.GetByCategoryIdAsync(categoryId, cancellationToken);

        return shortAdvertDtos.Count > 0 ? Ok(shortAdvertDtos) : NoContent();
    }

    /// <summary>
    /// Получение объявления по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных объявления.</returns>
    [HttpGet("get-by-id")]
    [ProducesResponseType(typeof(AdvertDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Поиск объявления по идентификатору: {@Id}", id);
        var advertDto = await _advertService.GetByIdAsync(id, cancellationToken);

        return advertDto is not null ? Ok(advertDto) : NoContent();
    }

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Объект передачи данных поискового запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    [HttpPost("get-by-search-request")]
    [ProducesResponseType(typeof(List<ShortAdvertDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetBySearchRequestAsync([FromBody] SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Поиск объявлений по запросу: {@Request}", request);
        var advertDtos = await _advertService.GetBySearchRequestAsync(request, cancellationToken);

        return advertDtos.Count > 0 ? Ok(advertDtos) : NoContent();
    }

    /// <summary>
    /// Выполняет получение объявлений по спецификации.
    /// </summary>
    /// <param name="request">Объект передачи данных поискового запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    [HttpPost("get-by-specification")]
    [ProducesResponseType(typeof(List<ShortAdvertDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> GetBySpecificationAsync([FromBody] SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        using var _ = LogContext.PushProperty("Request", request, true);
        _logger.LogInformation("Поиск объявлений по спецификации");

        var advertDtos = await _advertService.GetBySpecificationAsync(request, cancellationToken);

        return advertDtos.Count > 0 ? Ok(advertDtos) : NoContent();
    }
}
