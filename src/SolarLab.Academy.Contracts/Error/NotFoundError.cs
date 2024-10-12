namespace SolarLab.Academy.Contracts.Error
{
    /// <summary>
    /// Модель ошибки ненайденного объекта.
    /// </summary>
    public class NotFoundError : IApiProcessedError
    {
        /// <inheritdoc />
        public string? Type { get; set; }

        /// <inheritdoc />
        public string? Title { get; set; }

        /// <inheritdoc />
        public int StatusCode { get; set; }

        /// <inheritdoc />
        public IDictionary<string, string[]>? Errors { get; set; }

        /// <inheritdoc />
        public string? TraceId { get; set; }
    }
}
