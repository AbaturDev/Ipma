using Ipma.Api.Endpoints.Auth;
using Ipma.Api.Endpoints.EksperciIpma;

namespace Ipma.Api;

public static class ApiConfig
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        app.MapAuthEndpoints();
        app.MapEksperciIpmaEndpoints();
        
        return app;
    }
}