using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Account.Services;
using SolarLab.Academy.AppServices.Adverts.Repositories;
using SolarLab.Academy.AppServices.Adverts.Services;
using SolarLab.Academy.AppServices.Categories.Repositories;
using SolarLab.Academy.AppServices.Categories.Services;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.AppServices.User.Services;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.DataAccess.Repositories;
using SolarLab.Academy.Infrastructure.Repository;

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
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAdvertService, AdvertService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IAccountService, AccountService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();

        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(config => 
        {
            config.AddProfile<CategoryProfile>();
        });

        configuration.AssertConfigurationIsValid();

        return configuration;
    }
}