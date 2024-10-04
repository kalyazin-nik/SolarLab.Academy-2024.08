using Serilog.Context;
using SolarLab.Academy.AppServices.Services;

namespace SolarLab.Academy.Infrastructure.Services.Logging;

public class StructuralLoggingService : IStructuralLoggingService
{
    public IDisposable PushProperty(string name, object value, bool destructureObjects = false)
    {
        return LogContext.PushProperty(name, value, destructureObjects);
    }
}
