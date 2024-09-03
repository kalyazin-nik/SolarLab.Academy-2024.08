using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Services;

public interface IUserService
{
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken);
}
