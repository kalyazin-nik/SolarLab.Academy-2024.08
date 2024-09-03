using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.Infrastructure.FakeDB;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];
    private readonly List<UserDto> _usersDto = [];

    public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Task.FromResult<IReadOnlyCollection<UserDto>>(_usersDto);
    }

    public async Task<UserDto> RegisterAsync(UserDto model, string password, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            BirthDate = model.BirthDate,
            Email = model.Email,
            Login = model.Login,
            Password = password,
            IsBlocked = false,
            CreatedAt = DateTime.UtcNow
        };

        var userDto = new UserDto
        {
            ID = user.Id,
            Name = user.Name,
            BirthDate = user.BirthDate,
            Email = user.Email,
            Login = user.Login
        };

        _users.Add(user);
        _usersDto.Add(userDto);

        return await Task.FromResult(userDto);
    }
}
