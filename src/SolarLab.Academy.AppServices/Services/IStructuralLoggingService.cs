namespace SolarLab.Academy.AppServices.Services;

public interface IStructuralLoggingService
{
    IDisposable PushProperty(string name, object value, bool destructureObjects = false);
}
