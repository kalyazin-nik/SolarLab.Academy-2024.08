using SolarLab.Academy.AppServices.User.Repository;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.Infrastructure.FakeDB;

public class UserRepository : IUserRepository
{
    private List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }

    public Task<UserDto> Register(UserDto model, string password, CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            var user = new User
            {
                Id = model.ID,

            };

            _users.Add(user);

            return model;
        }, cancellationToken).WaitAsync(cancellationToken);
    }
}
