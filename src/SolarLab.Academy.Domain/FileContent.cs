namespace SolarLab.Academy.Domain;

/// <summary>
/// Сущность файла.
/// </summary>
public class FileContent : EntityBase
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public override Guid Id { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Контент.
    /// </summary>
    public byte[] Content { get; set; } = null!;

    /// <summary>
    /// Тип контента.
    /// </summary>
    public string ContentType { get; set; } = null!;

    /// <summary>
    /// Размер файла.
    /// </summary>
    public int Length { get; set; }
}
