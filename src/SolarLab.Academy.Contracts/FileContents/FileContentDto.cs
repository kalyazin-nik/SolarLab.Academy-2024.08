namespace SolarLab.Academy.Contracts.FileContents;

/// <summary>
/// Объект передачи данных файла.
/// </summary>
public class FileContentDto
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Контент.
    /// </summary>
    public byte[] Content { get; set; } = null!;

    /// <summary>
    /// Тип контента.
    /// </summary>
    public string ContentType { get; set; } = null!;
}
