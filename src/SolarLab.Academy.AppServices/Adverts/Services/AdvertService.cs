using SolarLab.Academy.AppServices.Adverts.Repositories;

namespace SolarLab.Academy.AppServices.Adverts.Services;

public class AdvertService(IAdvertRepository advertRepository) : IAdvertService
{
    private readonly IAdvertRepository _advertRepository = advertRepository;
}
