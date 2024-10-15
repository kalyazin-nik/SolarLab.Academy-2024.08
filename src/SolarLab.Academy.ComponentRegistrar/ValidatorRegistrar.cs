using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Contexts.Adverts.Validator;
using SolarLab.Academy.AppServices.Contexts.Categories.Validator;
using SolarLab.Academy.AppServices.Contexts.User.Validator;

namespace SolarLab.Academy.ComponentRegistrar;

public static class ValidatorRegistrar
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AdvertCreateValidator>();
        services.AddValidatorsFromAssemblyContaining<AdvertSearchRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<CategoryCreateValidator>();
        services.AddValidatorsFromAssemblyContaining<UserRegisterValidator>();

        services.AddFluentValidationAutoValidation();

        return services;
    }
}
