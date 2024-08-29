using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.Infrastructure.FakeDB;

public static class Users
{
    public static Dictionary<Guid, User> User = new();
    public static IEnumerable<User> Get()
    {
        var result = new List<User>()
        {
            new()
            {
                Id = Guid.Parse("96BFD5AF-0B7C-44BD-95CF-D2FA4ED8D151"),
                Name = "Иванов Иван Иванович",
                BirthDate = new DateTime(1996, 7, 12),
                Email = "ivanov@company.com",
                Login = "ivanov",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("52020998-767A-433A-AC14-B3CDA1BE852B"),
                Name = "Петров Пётр Петрович",
                BirthDate = new DateTime(1989, 6, 23),
                Email = "petrov@company.com",
                Login = "petrov",
                CreatedAt = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.Parse("59464F45-EBCB-4891-BBED-B44A5EC2F17C"),
                Name = "Захаров Захар Захарович",
                BirthDate = new DateTime(1999, 1, 21),
                Email = "zahar@company.com",
                Login = "zahar",
                CreatedAt = DateTime.UtcNow
            }
        };

        return result;
    }
}
