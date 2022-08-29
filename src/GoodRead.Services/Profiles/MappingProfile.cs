
using GoodRead.Domain.Entities;
using GoodRead.Services.Models.Book;
using GoodRead.Services.Models.UserRead;

namespace GoodRead.Services.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<UserRead, UserReadDto>().ReverseMap();
    }
}