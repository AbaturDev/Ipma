using Ipma.Api.Endpoints.EksperciIpma.Requests;
using Ipma.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Features.EksperciIpma.Verifying;

public static class VerifyEkspertIpma
{
    public static async Task<Results<NoContent, NotFound<ProblemDetails>>> HandleAsync(
        [FromRoute] Guid id,
        [FromBody] VerifyEkspertIpmaRequest request,
        [FromServices] IpmaDbContext context,
        CancellationToken ct)
    {
        var ekspert = await context.EksperciIpma
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (ekspert is null)
            return TypedResults.NotFound(new ProblemDetails
            {
                Title = "Not Found",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Ekspert IPMA with ID: '{id}' was not found."
            });
        
        ekspert.Status = request.Status;

        await context.SaveChangesAsync(ct);

        return TypedResults.NoContent();
    }
}
