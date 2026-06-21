using Ipma.Api.Endpoints.EksperciIpma.Requests;
using Ipma.Api.Endpoints.EksperciIpma.Responses;
using Ipma.Persistance;
using Ipma.Persistance.Entities;
using Ipma.Persistance.Entities.Owned;
using Ipma.Persistance.Enums;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ipma.Features.EksperciIpma.Creating;

public static class CreateEkspertIpma
{
    public static async Task<Created> HandleAsync(
        [FromBody] CreateEkspertIpmaRequest request,
        [FromServices] IpmaDbContext context,
        CancellationToken ct)
    {
        var ekspert = new EkspertIpma
        {
            RokUkończeniaSzkoleńPeb = request.RokUkończeniaSzkoleńPeb,
            Status = StatusEkspertaIpma.Aktywny,
            FlagaKonfliktuInteresów = false,
            DaneOsobowe = new DaneOsobowe
            {
                Imie = request.Imie,
                Nazwisko = request.Nazwisko,
                AdresEmail = request.AdresEmail,
                NrTelefonu = request.NrTelefonu
            }
        };

        context.EksperciIpma.Add(ekspert);
        await context.SaveChangesAsync(ct);

        return TypedResults.Created($"/api/eksperci-ipma/{ekspert.Id}");
    }
}
