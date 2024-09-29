using AutoMapper;
using SolarLab.Academy.AppServices.Helpers;
using SolarLab.Academy.Contracts.User;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>(MemberList.None);
        CreateMap<User, UserLoginRequestDto>(MemberList.None);
        CreateMap<User, UserLoginResponseDto>(MemberList.None);

        CreateMap<UserRegisterRequestDto, User>(MemberList.None)
            .ForMember(x => x.CreeatedAt, map => map.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.Password, map => map.MapFrom(x => CryptoHelper.GetBase64Hash(x.Password)));
    }
}
