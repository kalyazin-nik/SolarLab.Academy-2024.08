using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Repository;

public interface IUserRepository
{
    Task<UserDto> Register(UserDto model, string password, CancellationToken cancellationToken);
}
