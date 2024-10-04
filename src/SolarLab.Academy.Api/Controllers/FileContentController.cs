using Microsoft.AspNetCore.Mvc;
using SolarLab.Academy.AppServices.Contexts.FileContent.Services;
using SolarLab.Academy.Contracts.FileContents;
using System.Net;

namespace SolarLab.Academy.Api.Controllers
{
    /// <summary>
    /// Контроллер по работе с файлами.
    /// </summary>
    /// <param name="fileContentService">Сервис по работе с файлами.</param>
    /// <param name="logger">Логгер <see cref="FileContentController"/></param>
    [ApiController]
    [Route("file")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public class FileContentController(IFileContentService fileContentService, ILogger<FileContentController> logger) : ControllerBase
    {
        private readonly IFileContentService _fileContentService = fileContentService;
        private readonly ILogger<FileContentController> _logger = logger;

        /// <summary>
        /// Загрузка файла в систему.
        /// </summary>
        /// <param name="file">Файл.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Идентификатор файла.</returns>
        [HttpPost("upload")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> UploadAsync(IFormFile file, CancellationToken cancellationToken)
        {
            var fileId = await _fileContentService.UploadAsync(file, cancellationToken);

            return StatusCode((int)HttpStatusCode.Accepted, fileId);
        }

        /// <summary>
        /// Скачивание файла по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Файл для скачивания.</returns>
        [HttpGet("download/{id}")]
        [ProducesResponseType(typeof(FileContentResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DownloadAsync(Guid id, CancellationToken cancellationToken)
        {
            var file = await _fileContentService.GetFileAsync(id, cancellationToken);
            Response.ContentLength = file?.Content.Length;

            return file is not null ? File(file.Content, file.ContentType, file.Name) : NoContent();
        }

        /// <summary>
        /// Получение информации о файле по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены операции.</param>
        /// <returns>Объект передачи данных информации о файле.</returns>
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(FileContentInfoDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Nullable), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetFileInfoByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var fileInfo = await _fileContentService.GetFileInfoByIdAsync(id, cancellationToken);

            return fileInfo is not null ? Ok(fileInfo) : NoContent();
        }
    }
}
