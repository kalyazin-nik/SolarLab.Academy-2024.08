using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<UserDto> Register(UserRegisterRequestDto model, CancellationToken cancellationToken)
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

        return _userRepository.Register(userDto, password, cancellationToken);
    }
}
