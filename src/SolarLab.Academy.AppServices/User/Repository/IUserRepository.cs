using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Repository;

public interface IUserRepository
{
    Task<UserDto> RegisterAsync(UserDto model, string password, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<UserDto> GetUserAsync(Guid id, CancellationToken cancellationToken);
}
