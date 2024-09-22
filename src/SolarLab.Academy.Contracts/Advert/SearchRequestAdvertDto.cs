namespace SolarLab.Academy.Contracts.Advert;

/// <summary>
/// Объект передачи данных поискового запроса объявления.
/// </summary>
public class SearchRequestAdvertDto
{
    /// <summary>
    /// Поисковой запрос.
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Минимальная стоимость.
    /// </summary>
    public decimal? MinPrice { get; set; }

    /// <summary>
    /// Максимальная стоимость.
    /// </summary>
    public decimal? MaxPrice { get; set; }

    /// <summary>
    /// Включение не активных объявлений.
    /// </summary>
    public bool? IncludeDisabled { get; set; }

    /// <summary>
    /// Количество элементов для пропуска.
    /// </summary>
    public int? Skip {  get; set; }

    /// <summary>
    /// Количество элементов для выдачи.
    /// </summary>
    public int Take { get; set; }
}
