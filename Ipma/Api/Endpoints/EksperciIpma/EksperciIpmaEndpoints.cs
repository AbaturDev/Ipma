using Ipma.Extensions;
using Ipma.Features.EksperciIpma.Creating;
using Ipma.Features.EksperciIpma.Deleting;
using Ipma.Features.EksperciIpma.Getting;
using Ipma.Features.EksperciIpma.Updating;
using Ipma.Features.EksperciIpma.Verifying;

namespace Ipma.Api.Endpoints.EksperciIpma;

public static class EksperciIpmaEndpoints
{
    public static RouteGroupBuilder MapEksperciIpmaEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/api/eksperci-ipma")
            .RequireAuthorization(Policies.PrzedstawicielBiuraNagrody);

        group.MapGet("", ListEkspertIpmas.HandleAsync);
        group.MapGet("/{id:guid}", GetEkspertIpma.HandleAsync);
        group.MapPost("", CreateEkspertIpma.HandleAsync);
        group.MapPut("/{id:guid}", UpdateEkspertIpma.HandleAsync);
        group.MapDelete("/{id:guid}", DeleteEkspertIpma.HandleAsync);
        group.MapPost("/{id:guid}/verify", VerifyEkspertIpma.HandleAsync);

        return group;
    }
}
