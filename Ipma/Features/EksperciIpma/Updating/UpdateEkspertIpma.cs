using Ipma.Api.Endpoints.EksperciIpma.Requests;
using Ipma.Api.Endpoints.EksperciIpma.Responses;
using Ipma.Persistance;
using Ipma.Persistance.Entities;
using Ipma.Persistance.Entities.Owned;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Features.EksperciIpma.Updating;

public static class UpdateEkspertIpma
{
    public static async Task<Results<NoContent, NotFound<ProblemDetails>>> HandleAsync(
        [FromRoute] Guid id,
        [FromBody] UpdateEkspertIpmaRequest request,
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

        ekspert.RokUkończeniaSzkoleńPeb = request.RokUkończeniaSzkoleńPeb;
        ekspert.DaneOsobowe = new DaneOsobowe
        {
            Imie = request.Imie,
            Nazwisko = request.Nazwisko,
            AdresEmail = request.AdresEmail,
            NrTelefonu = request.NrTelefonu
        };

        await context.SaveChangesAsync(ct);

        return TypedResults.NoContent();
    }
}
