using Ipma.Api.Endpoints.Auth.Requests;
using Ipma.Api.Filters;
using Ipma.Features.Auth;

namespace Ipma.Api.Endpoints.Auth;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/auth")
            .AllowAnonymous();

        group.MapPost("/login", Login.HandleAsync)
            .AddEndpointFilter<ValidationFilter<LoginRequest>>();

        return group;
    }
}
