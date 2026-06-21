using Ipma.Services.Jwt;
using Ipma.Services.Jwt.Abstractions;
using Ipma.Services.PasswordHasher;
using Ipma.Services.PasswordHasher.Abstractions;

namespace Ipma.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        
        return services;
    }
}