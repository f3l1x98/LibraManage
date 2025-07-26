using LibraManage.Profiles;

namespace LibraManage.Extensions;

public static class MapperExtension
{
    public static IServiceCollection RegisterAutoMapperProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(BookProfile));
        return services;
    }
}
