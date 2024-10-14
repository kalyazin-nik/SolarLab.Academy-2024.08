using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.FileContent.Services;
using SolarLab.Academy.Contracts.Error;
using SolarLab.Academy.Contracts.FileContents;
using System.Net;

namespace SolarLab.Academy.Api.Controllers
{
    /// <summary>
    /// Контроллер по работе с файлами.
    /// </summary>
    /// <param name="fileContentService">Сервис по работе с файлами.</param>
    [ApiController]
    [Route("file")]
    [ProducesResponseType(typeof(InternalServerError), (int)HttpStatusCode.InternalServerError)]
    public class FileContentController(IFileContentService fileContentService) : ControllerBase
    {
        private readonly IFileContentService _fileContentService = fileContentService;

        /// <summary>
        /// Загрузка файла в систему.
        /// </summary>
        /// <param name="file">Файл.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор файла.</returns>
        [HttpPost("upload")]
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> UploadAsync(IFormFile? file, CancellationToken cancellationToken)
        {
            return StatusCode((int)HttpStatusCode.Accepted, await _fileContentService.UploadAsync(file, cancellationToken));
        }

        /// <summary>
        /// Скачивание файла по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель файла для скачивания.</returns>
        [HttpGet("download")]
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DownloadAsync(Guid? id, CancellationToken cancellationToken)
        {
            var file = await _fileContentService.GetFileAsync(id, cancellationToken);
            Response.ContentLength = file.Content.Length;

            return File(file.Content, file.ContentType, file.Name);
        }

        /// <summary>
        /// Получение информации о файле по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Модель информации о файле.</returns>
        [HttpGet("get")]
        [ProducesResponseType(typeof(BadRequestError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NotFoundError), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(FileContentInfoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFileInfoByIdAsync(Guid? id, CancellationToken cancellationToken)
        {
            return Ok(await _fileContentService.GetFileInfoByIdAsync(id, cancellationToken));
        }
    }
}
