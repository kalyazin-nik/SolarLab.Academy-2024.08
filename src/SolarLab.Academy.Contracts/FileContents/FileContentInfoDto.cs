namespace SolarLab.Academy.Contracts.FileContents;

/// <summary>
/// Объект передачи данных информации о файле.
/// </summary>
public class FileContentInfoDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Размер файла.
    /// </summary>
    public int Length { get; set; }
}
