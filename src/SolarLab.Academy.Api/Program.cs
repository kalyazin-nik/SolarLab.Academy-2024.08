using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using SolarLab.Academy.Api.Controllers;
using SolarLab.Academy.Api.Middlewares;
using SolarLab.Academy.ComponentRegistrar;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Contracts.Error;
using SolarLab.Academy.Contracts.FileContents;
using SolarLab.Academy.Contracts.Order;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.DataAccess;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SolarLab.Academy.Api;

/// <summary>
/// Главный класс программы.
/// </summary>
public class Program
{
    private static readonly Type[] _docTypeMarkers =
    [
        typeof(UserDto),
        typeof(UserRegisterRequestDto),
        typeof(UserLoginRequestDto),
        typeof(UserLoginResponseDto),
        typeof(CategoryDto),
        typeof(CategoryCreateDto),
        typeof(AdvertDto),
        typeof(AdvertSmallDto),
        typeof(AdvertCreateDto),
        typeof(AdvertSearchRequestDto),
        typeof(OrderDto),
        typeof(OrderItemDto),
        typeof(FileContentDto),
        typeof(FileContentInfoDto),
        typeof(AccountController),
        typeof(AdvertController),
        typeof(CategoryController),
        typeof(FileContentController),
        typeof(UserController),
        typeof(BadRequestError),
        typeof(DevelopmentError)
    ];

    /// <summary>
    /// Точка входа программы.
    /// </summary>
    /// <param name="args">Аргументы первоначалльной настройки программы.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen(ConfigureSwaggerOptions);
        builder.Services.AddApplicationServices();
        builder.Services.AddDbContext<AcademyDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));
        builder.Services.AddValidator();
        builder.Host.AddSerilog();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var secretKey = builder.Configuration["Jwt:Key"]!;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = false,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        builder.Services.AddAuthorization();

        var app = builder.Build();
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }

    private static void ConfigureSwaggerOptions(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Academy API",
            Version = "v1"
        });

        options.SetIncludeXmlComments(_docTypeMarkers);
        options.SetSecurityDefinition();
        options.SetSecurityRequirement();
    }
}
