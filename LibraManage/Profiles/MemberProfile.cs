using AutoMapper;
using Domain.Members;
using LibraManage.Dtos.Members;

namespace LibraManage.Profiles;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<Member, MemberDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
    }
}
