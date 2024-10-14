using AutoMapper;
using Microsoft.AspNetCore.Http;
using SolarLab.Academy.Contracts.FileContents;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class FileContentProfile : Profile
{
    public FileContentProfile()
    {
        CreateMap<FileContent, FileContentInfoDto>(MemberList.None);

        CreateMap<FileContent, FileContentDto>(MemberList.None);

        CreateMap<IFormFile, FileContent>(MemberList.None)
            .ForMember(x => x.CreatedAt, map => map.MapFrom(x => DateTime.UtcNow))
            .ForMember(x => x.Name, map => map.MapFrom(x => x.FileName))
            .ForMember(x => x.Content, map => map.MapFrom(x => GetBytes(x)));
    }

    private static byte[] GetBytes(IFormFile file)
    {
        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);

        return memoryStream.ToArray();
    }
}
