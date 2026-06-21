using Ipma.Api.Endpoints.EksperciIpma.Dtos;
using Ipma.Api.Endpoints.EksperciIpma.Responses;
using Ipma.Persistance;
using Ipma.Persistance.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Features.EksperciIpma.Getting;

public static class ListEkspertIpmas
{
    public static async Task<Ok<ListEkspertIpmaResponse>> HandleAsync(
        [FromServices] IpmaDbContext context,
        CancellationToken ct)
    {
        var eksperci = await context.EksperciIpma
            .AsNoTracking()
            .ToListAsync(ct);

        var ekspertsList = eksperci.Select(x => new EkspertIpmaDto
        {
            Id = x.Id,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt,
            RokUkończeniaSzkoleńPeb = x.RokUkończeniaSzkoleńPeb,
            Status = x.Status,
            FlagaKonfliktuInteresów = x.FlagaKonfliktuInteresów,
            Imie = x.DaneOsobowe.Imie,
            Nazwisko = x.DaneOsobowe.Nazwisko,
            AdresEmail = x.DaneOsobowe.AdresEmail,
            NrTelefonu = x.DaneOsobowe.NrTelefonu,
        }).ToList();

        var response = new ListEkspertIpmaResponse
        {
            Count = ekspertsList.Count,
            EkspertIpmas = ekspertsList
        };
        
        return TypedResults.Ok(response);
    }
}
