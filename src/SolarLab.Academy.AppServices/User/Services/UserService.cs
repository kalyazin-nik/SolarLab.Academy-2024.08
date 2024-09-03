using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }
}
