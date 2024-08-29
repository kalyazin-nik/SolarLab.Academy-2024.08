namespace SolarLab.Academy.AppServices.WeatherForecast.Services;

/// <summary>
/// TODO.
/// </summary>
public interface IWeatherForecastService
{
    /// <summary>
    /// TODO
    /// </summary>
    /// <returns>TODO</returns>
    Task<IEnumerable<Domain.WeatherForecasts.WeatherForecast>> Get();
}
