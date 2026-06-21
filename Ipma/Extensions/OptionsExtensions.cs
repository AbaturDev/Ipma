using Ipma.Options;

namespace Ipma.Extensions;

public static class OptionsExtensions
{
    public static IServiceCollection AddOptions<TOptions>(
        this IServiceCollection services, 
        string sectionName) 
        where TOptions : class
    {
        services.AddOptions<TOptions>()
            .BindConfiguration(sectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        return services;
    }

    public static IServiceCollection RegisterOptions(this IServiceCollection services)
    {
        services.AddOptions<JwtOptions>(JwtOptions.SectionName);
        
        return services;
    }
}