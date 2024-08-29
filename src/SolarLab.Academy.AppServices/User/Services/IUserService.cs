using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Services;

public interface IUserService
{
    Task<UserDto> Register(UserRegisterRequestDto model, CancellationToken cancellationToken);
}
