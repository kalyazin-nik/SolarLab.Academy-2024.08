using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Account.Services;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.AppServices.User.Services;

namespace SolarLab.Academy.ComponentRegistrar;

/// <summary>
/// Класс регистрации компонентов.
/// </summary>
public static class ComponentRegistrar
{
    /// <summary>
    /// Добавление служб приложений.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов с добавленными службами приложения.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAccountService, AccountService>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}