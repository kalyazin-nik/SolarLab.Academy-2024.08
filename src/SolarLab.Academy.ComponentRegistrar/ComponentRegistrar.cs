using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Contexts.Account.Services;
using SolarLab.Academy.AppServices.Contexts.Adverts.Repositories;
using SolarLab.Academy.AppServices.Contexts.Adverts.Services;
using SolarLab.Academy.AppServices.Contexts.Categories.Repositories;
using SolarLab.Academy.AppServices.Contexts.Categories.Services;
using SolarLab.Academy.AppServices.Contexts.FileContent.Repositories;
using SolarLab.Academy.AppServices.Contexts.FileContent.Services;
using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Contexts.User.Services;
using SolarLab.Academy.AppServices.Services;
using SolarLab.Academy.AppServices.Validator;
using SolarLab.Academy.ComponentRegistrar.MapProfiles;
using SolarLab.Academy.DataAccess.Repositories;
using SolarLab.Academy.Infrastructure.Adverts.Builders;
using SolarLab.Academy.Infrastructure.Repository;
using SolarLab.Academy.Infrastructure.Services.Logging;

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
        services.AddScoped<IFileContentService, FileContentService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAdvertRepository, AdvertRepository>();
        services.AddScoped<IFileContentRepository, FileContentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IValidationService, ValidationService>();
        services.AddScoped<IAdvertSpecificationBuilder, AdvertSpecificationBuilder>();
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

        services.AddScoped<IStructuralLoggingService, StructuralLoggingService>();

        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(config => 
        {
            config.AddProfile<CategoryProfile>();
            config.AddProfile<AdvertProfile>();
            config.AddProfile<FileContentProfile>();
            config.AddProfile<UserProfile>();
        });

        configuration.AssertConfigurationIsValid();

        return configuration;
    }
}