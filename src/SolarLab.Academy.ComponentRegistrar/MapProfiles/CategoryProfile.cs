using AutoMapper;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();

        CreateMap<CategoryCreateDto, Category>(MemberList.None)
            .ForMember(x => x.CreatedAt, map => map.MapFrom(x => DateTime.UtcNow));
    }
}
