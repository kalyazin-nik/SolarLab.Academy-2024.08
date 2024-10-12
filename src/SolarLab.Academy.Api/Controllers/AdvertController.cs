using System.Net;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Sevice;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Error;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с объявлениями.
/// </summary>
/// <param name="advertService">Сервис по работе с объявлениями.</param>
/// <param name="validatorService">Сервис по работе с валидациями запросов.</param>
/// <param name="logger">Логгер <see cref="AdvertController"/></param>
[ApiController]
[Route("advert")]
[ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
public class AdvertController(IAdvertService advertService, IAdvertValidatorService validatorService, ILogger<AdvertController> logger) : ControllerBase
{
    private readonly IAdvertService _advertService = advertService;
    private readonly IAdvertValidatorService _validatorService = validatorService;
    private readonly ILogger<AdvertController> _logger = logger;

    /// <summary>
    /// Создание обяевления.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор объявления.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateAsync([FromBody] CreateAdvertDto dto, CancellationToken cancellationToken)
    {
        var advertId = await _advertService.CreateAsync(dto, cancellationToken);
        return StatusCode((int)HttpStatusCode.Created, advertId);
    }

    /// <summary>
    /// Получение коллекции объявлений по идентификатору категории.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объектов передачи данных объявлений в сокращенном виде.</returns>
    [HttpGet("getByCategory")]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvertDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        var shortAdvertDtos = await _advertService.GetByCategoryIdAsync(id, cancellationToken);
        return Ok(shortAdvertDtos);
    }

    /// <summary>
    /// Получение объявления по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных объявления.</returns>
    [HttpGet("get")]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(AdvertDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var advertDto = await _advertService.GetByIdAsync(id, cancellationToken);
        return Ok(advertDto);
    }

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Объект передачи данных поискового запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    [HttpPost("getBySearchRequest")]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<ShortAdvertDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBySearchRequestAsync([FromBody] SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Поиск объявлений по запросу: {@Request}", request);
        var advertDtos = await _advertService.GetBySearchRequestAsync(request, cancellationToken);

        return advertDtos.Count > 0 ? Ok(advertDtos) : NotFound();
    }

    /// <summary>
    /// Выполняет получение объявлений по спецификации.
    /// </summary>
    /// <param name="request">Объект передачи данных поискового запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    [HttpPost("getBySpecification")]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<ShortAdvertDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBySpecificationAsync([FromBody] SearchRequestAdvertDto request, CancellationToken cancellationToken)
    {
        using var _ = LogContext.PushProperty("Request", request, true);
        _logger.LogInformation("Поиск объявлений по спецификации");

        var advertDtos = await _advertService.GetBySpecificationAsync(request, cancellationToken);

        return advertDtos.Count > 0 ? Ok(advertDtos) : NotFound();
    }
}
