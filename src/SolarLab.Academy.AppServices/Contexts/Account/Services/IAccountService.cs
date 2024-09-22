using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.Account.Services;

public interface IAccountService
{
    Task<UserDto> RegisterAsync(UserRegisterRequestDto model, CancellationToken cancellationToken);
}
