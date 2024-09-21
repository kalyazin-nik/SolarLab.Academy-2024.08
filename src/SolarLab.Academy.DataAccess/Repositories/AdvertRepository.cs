using SolarLab.Academy.AppServices.Adverts.Repositories;
using SolarLab.Academy.Domain;
using SolarLab.Academy.Infrastructure.Repository;

namespace SolarLab.Academy.DataAccess.Repositories;

public class AdvertRepository(IRepository<Advert, AcademyDbContext> repository) : IAdvertRepository
{
    private readonly IRepository<Advert, AcademyDbContext> _repository = repository;
}
