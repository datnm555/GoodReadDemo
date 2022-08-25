
using GoodRead.Services.Models.Book;

namespace GoodRead.Services.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
    }
}