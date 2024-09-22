using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.Account.Services;

public class AccountService(IUserRepository userRepository) : IAccountService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<UserDto> RegisterAsync(UserRegisterRequestDto model, CancellationToken cancellationToken)
    {
        var userDto = new UserDto
        {
            ID = Guid.NewGuid(),
            Name = model.Name,
            BirthDate = model.BirthDate,
            Login = model.Login,
            Email = model.Email,
        };

        var password = CryptoHelper.GetBase64Hash(model.Password);

        return await _userRepository.RegisterAsync(userDto, password, cancellationToken);
    }
}
