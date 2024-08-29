using SolarLab.Academy.Domain.Entities;

namespace SolarLab.Academy.Infrastructure.FakeDB;

public static class Orders
{
    public static IEnumerable<Order> Get()
    {
        var result = new List<Order>()
        {
            new()
            {
                Id = Guid.Parse("E5BE04D2-5D07-41D3-8A32-C1A4505846E2"),
                TotalCount = 10,
                Amount = 200,
                Comment = "Comment -> {E5BE04D2-5D07-41D3-8A32-C1A4505846E2}",
                Description = "Description -> {E5BE04D2-5D07-41D3-8A32-C1A4505846E2}",
                CreatedAt = DateTime.UtcNow,
                UserID = Guid.Parse("96BFD5AF-0B7C-44BD-95CF-D2FA4ED8D151"),
            },
            new()
            {
                Id = Guid.Parse("8C11F7C1-BDDA-49D7-98DA-737359BC6FC0"),
                TotalCount = 8,
                Amount = 300,
                Comment = "Comment -> {8C11F7C1-BDDA-49D7-98DA-737359BC6FC0}",
                Description = "Description -> {8C11F7C1-BDDA-49D7-98DA-737359BC6FC0}",
                CreatedAt = DateTime.UtcNow,
                UserID = Guid.Parse("52020998-767A-433A-AC14-B3CDA1BE852B")
            },
            new()
            {
                Id = Guid.Parse("4ECC4F09-DEA4-4962-90C7-A29828A96455"),
                TotalCount = 6,
                Amount = 150,
                Comment = "Comment -> {4ECC4F09-DEA4-4962-90C7-A29828A96455}",
                Description = "Description -> {4ECC4F09-DEA4-4962-90C7-A29828A96455}",
                CreatedAt = DateTime.UtcNow,
                UserID = Guid.Parse("52020998-767A-433A-AC14-B3CDA1BE852B")
            }
        };

        return result;
    }
}
