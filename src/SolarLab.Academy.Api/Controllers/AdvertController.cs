using System.Net;
using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Adverts.Services;

namespace SolarLab.Academy.Api.Controllers;

/// <summary>
/// Контроллер по работе с объявлениями.
/// </summary>
/// <param name="advertService">Сервис по работе с объявлениями.</param>
[ApiController]
[Route("advert")]
[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
public class AdvertController(IAdvertService advertService) : ControllerBase
{
    private readonly IAdvertService _advertService = advertService;
}
