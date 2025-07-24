namespace LibraManage.Extensions;

public static class MapperExtension
{
    public static IServiceCollection RegisterAutoMapperProfiles(this IServiceCollection services)
    {
        // TODO services.AddAutoMapper(typeof(BookProfile)) etc
        return services;
    }
}
