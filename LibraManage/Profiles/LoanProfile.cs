using AutoMapper;
using Domain.Loans;
using LibraManage.Dtos.Loans;

namespace LibraManage.Profiles;

public sealed class LoanProfile : Profile
{
    public LoanProfile()
    {
        CreateMap<Loan, LoanDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value));
    }
}
