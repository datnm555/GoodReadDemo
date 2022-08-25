
namespace GoodRead.Services.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}