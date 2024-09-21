using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using SolarLab.Academy.Api.Controllers;
using SolarLab.Academy.Api.Middlewares;
using SolarLab.Academy.ComponentRegistrar;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.DataAccess;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SolarLab.Academy.Api;

/// <summary>
/// Главный класс программы.
/// </summary>
public class Program
{
    /// <summary>
    /// Точка входа программы.
    /// </summary>
    /// <param name="args">Аргументы первоначалльной настройки программы.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(AddSwaggerGen);
        builder.Services.AddApplicationServices();
        builder.Services.AddDbContext<AcademyDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

        var app = builder.Build();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private static void AddSwaggerGen(SwaggerGenOptions options)
    {
        var docTypeMarkers = new[] { typeof(UserDto), typeof(UserController), typeof(AccountController) };

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Academy API",
            Version = "v1"
        });

        foreach (var marker in docTypeMarkers)
        {
            var xmlFile = $"{marker.Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        }
    }
}
