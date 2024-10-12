using AutoMapper;
using SolarLab.Academy.Contracts.Advert;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class AdvertProfile : Profile
{
    public AdvertProfile()
    {
        CreateMap<Advert, AdvertDto>(MemberList.None);

        CreateMap<Advert, AdvertSmallDto>(MemberList.None);

        CreateMap<AdvertCreateDto, Advert>(MemberList.None)
            .ForMember(x => x.CreatedAt, map => map.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.Disabled, map => map.MapFrom(x => false));
    }
}
