using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.DataAccess;

namespace SolarLab.Academy.DbMigrator;

public class MigrationDbContext(DbContextOptions options) : AcademyDbContext(options)
{
}
