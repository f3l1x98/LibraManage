using LibraManage.Profiles;

namespace LibraManage.Extensions;

public static class MapperExtension
{
    public static IServiceCollection RegisterAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookProfile));
        services.AddAutoMapper(typeof(MemberProfile));
        services.AddAutoMapper(typeof(LoanProfile));
        return services;
    }
}
