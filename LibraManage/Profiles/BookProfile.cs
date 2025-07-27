using AutoMapper;
using Domain.Books;
using LibraManage.Dtos.Books;

namespace LibraManage.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
    }
}
