using Microsoft.EntityFrameworkCore;

namespace SolarLab.Academy.DbMigrator;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureDbConnection(configuration);

        return services;
    }

    private static IServiceCollection ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresConnection = configuration.GetConnectionString("PostgresConnection");
        services.AddDbContext<MigrationDbContext>(options => options.UseNpgsql(postgresConnection));

        return services;
    }
}
