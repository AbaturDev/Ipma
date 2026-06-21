using Ipma.Api.Endpoints.Auth;

namespace Ipma.Api;

public static class ApiConfig
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapAuthEndpoints();
        
        return app;
    }
}