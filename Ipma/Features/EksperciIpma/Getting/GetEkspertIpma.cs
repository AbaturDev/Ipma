using Ipma.Api.Endpoints.EksperciIpma.Dtos;
using Ipma.Persistance;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Features.EksperciIpma.Getting;

public static class GetEkspertIpma
{
    public static async Task<Results<Ok<EkspertIpmaDto>, NotFound<ProblemDetails>>> HandleAsync(
        [FromRoute] Guid id,
        [FromServices] IpmaDbContext context,
        CancellationToken ct)
    {
        var ekspert = await context.EksperciIpma
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id, ct);

        if (ekspert is null)
            return TypedResults.NotFound(new ProblemDetails
            {
                Title = "Not Found",
                Status = StatusCodes.Status404NotFound,
                Detail = $"Ekspert IPMA with ID: '{id}' was not found."
            });


        var dto = new EkspertIpmaDto
        {
            Id = ekspert.Id,
            CreatedAt = ekspert.CreatedAt,
            UpdatedAt = ekspert.UpdatedAt,
            RokUkończeniaSzkoleńPeb = ekspert.RokUkończeniaSzkoleńPeb,
            Status = ekspert.Status,
            FlagaKonfliktuInteresów = ekspert.FlagaKonfliktuInteresów,
            Imie = ekspert.DaneOsobowe.Imie,
            Nazwisko = ekspert.DaneOsobowe.Nazwisko,
            AdresEmail = ekspert.DaneOsobowe.AdresEmail,
            NrTelefonu = ekspert.DaneOsobowe.NrTelefonu,
        };
        
        return TypedResults.Ok(dto);
    }
}
