using Ipma.Features.Auth;

namespace Ipma.Api.Endpoints.Auth;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/auth");

        group.MapPost("/login", Login.HandleAsync);
        
        return group;
    }
}