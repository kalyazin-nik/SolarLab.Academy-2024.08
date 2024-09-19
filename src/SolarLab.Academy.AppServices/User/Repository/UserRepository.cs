using SolarLab.Academy.AppServices.Exceptions;
using SolarLab.Academy.Contracts.User;

namespace SolarLab.Academy.AppServices.User.Repository;

public class UserRepository : IUserRepository
{
    //private readonly Dictionary<Guid, User> _users = [];

    //public async Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    //{
    //    if (_users.Count is 0)
    //    {
    //        throw new EntitiesNotFoundException("Сущности пользователей не были найдены.");
    //    }

    //    return await Task.FromResult<IReadOnlyCollection<UserDto>>(_users.Values.Select(GetUserDto).ToList());
    //}

    //public async Task<UserDto> GetUserAsync(Guid id, CancellationToken cancellationToken)
    //{
    //    return await Task.FromResult(TryGetUserDto(id));
    //}

    //public async Task<UserDto> RegisterAsync(UserDto model, string password, CancellationToken cancellationToken)
    //{
    //    var user = new User
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = model.Name,
    //        BirthDate = model.BirthDate,
    //        Email = model.Email,
    //        Login = model.Login,
    //        Password = password,
    //        IsBlocked = false,
    //        CreatedAt = DateTime.UtcNow
    //    };

    //    var userDto = new UserDto
    //    {
    //        ID = user.Id,
    //        Name = user.Name,
    //        BirthDate = user.BirthDate,
    //        Email = user.Email,
    //        Login = user.Login
    //    };

    //    _users.Add(user.Id, user);

    //    return await Task.FromResult(userDto);
    //}

    //private UserDto TryGetUserDto(Guid id)
    //{
    //    _users.TryGetValue(id, out var user);

    //    if (user is null)
    //    {
    //        throw new EntityNotFoundException();
    //    }

    //    return GetUserDto(user);
    //}

    //private UserDto GetUserDto(User user)
    //{
    //    return new UserDto
    //    {
    //        ID = user.Id,
    //        Name = user.Name,
    //        BirthDate = user.BirthDate,
    //        Email = user.Email,
    //        Login = user.Login
    //    };
    //}
    public Task<IReadOnlyCollection<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> RegisterAsync(UserDto model, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
