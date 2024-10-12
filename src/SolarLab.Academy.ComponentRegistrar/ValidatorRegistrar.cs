using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SolarLab.Academy.AppServices.Contexts.Adverts.Validator.Models;

namespace SolarLab.Academy.ComponentRegistrar;

public static class ValidatorRegistrar
{
    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateAdvertValidator>();

        services.AddFluentValidationAutoValidation();

        return services;
    }
}
