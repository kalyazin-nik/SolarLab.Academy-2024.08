using System.Net;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Error;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с объявлениями.
/// </summary>
/// <param name="advertService">Сервис по работе с объявлениями.</param>
[ApiController]
[Route("advert")]
[ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
public class AdvertController(IAdvertService advertService) : ControllerBase
{
    private readonly IAdvertService _advertService = advertService;

    /// <summary>
    /// Создание обяевления.
    /// </summary>
    /// <param name="dto">Объект передачи данных создания объявления.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Идентификатор объявления.</returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> CreateAsync([FromBody] AdvertCreateDto dto, CancellationToken cancellationToken)
    {
        return StatusCode((int)HttpStatusCode.Created, await _advertService.CreateAsync(dto, cancellationToken));
    }

    /// <summary>
    /// Получение коллекции объявлений по идентификатору категории.
    /// </summary>
    /// <param name="id">Идентификатор категории.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Коллекция объектов передачи данных объявлений в сокращенном виде.</returns>
    [HttpGet("getByCategory")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(IReadOnlyCollection<AdvertDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByCategoryIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        return Ok(await _advertService.GetByCategoryIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Получение объявления по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Объект передачи данных объявления.</returns>
    [HttpGet("get")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(AdvertDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid? id, CancellationToken cancellationToken)
    {
        return Ok(await _advertService.GetByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Выполняет получение объявлений по поисковому запросу.
    /// </summary>
    /// <param name="request">Объект передачи данных поискового запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Колеекция моделей объявлений в сокращенном виде.</returns>
    [HttpPost("getBySearchRequest")]
    [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<AdvertSmallDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBySearchRequestAsync([FromBody] AdvertSearchRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _advertService.GetBySearchRequestAsync(request, cancellationToken));
    }
}
