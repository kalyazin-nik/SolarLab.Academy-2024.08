using SolarLab.Academy.AppServices.Contexts.User.Repository;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.Contexts.User.Services;

/// <summary>
/// Сервис по работе с пользователями.
/// </summary>
/// <param name="userRepository">Репозиторий по работе с пользователями.</param>
public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;

    /// <inheritdoc />
    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(id, cancellationToken);
    }
}
