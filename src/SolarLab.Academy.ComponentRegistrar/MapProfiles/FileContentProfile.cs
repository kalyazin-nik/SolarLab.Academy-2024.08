using AutoMapper;
using SolarLab.Academy.Contracts.FileContents;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class FileContentProfile : Profile
{
    public FileContentProfile()
    {
        CreateMap<FileContent, FileContentInfoDto>(MemberList.None);

        CreateMap<FileContent, FileContentDto>(MemberList.None);

        CreateMap<FileContentDto, FileContent>(MemberList.None)
            .ForMember(x => x.CreatedAt, map => map.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.Length, map => map.MapFrom(x => x.Content.Length));
    }
}
