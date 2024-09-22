using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<UserDto> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userRepository.GetUserAsync(id, cancellationToken);
    }
}
