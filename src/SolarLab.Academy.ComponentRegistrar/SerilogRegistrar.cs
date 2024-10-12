using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace SolarLab.Academy.ComponentRegistrar;

public static class SerilogRegistrar
{
    private const string Path = "SolarLab.Academy.ComponentRegistrar.Appsettings.serilog.json";

    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder)
    {
        if (TryReadStreamSerilogJSON())
        {
            hostBuilder.UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                using var stream = GetStreamSerilogJSON()!;
                var serilogConfiguration = GetSerilogConfiguration(stream);

                loggerConfiguration.ReadFrom
                    .Configuration(serilogConfiguration)
                    .Enrich
                    .WithEnvironmentName();
            });
        }

        return hostBuilder;
    }

    private static bool TryReadStreamSerilogJSON()
    {
        using var stream = GetStreamSerilogJSON();

        return stream is not null;
    }

    private static Stream? GetStreamSerilogJSON()
    {
        return Assembly
            .GetExecutingAssembly()
            .GetManifestResourceStream(Path);
    }

    private static IConfiguration GetSerilogConfiguration(Stream stream)
    {
        return new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
    }
}
