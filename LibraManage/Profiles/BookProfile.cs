using AutoMapper;
using Domain.Books;
using LibraManage.Dtos;

namespace LibraManage.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
    }
}
