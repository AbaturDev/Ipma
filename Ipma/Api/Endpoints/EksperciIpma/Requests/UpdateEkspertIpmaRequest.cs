namespace Ipma.Api.Endpoints.EksperciIpma.Requests;

public sealed record UpdateEkspertIpmaRequest
{
    public required int RokUkończeniaSzkoleńPeb { get; init; }
    public required string Imie { get; init; }
    public required string Nazwisko { get; init; }
    public required string AdresEmail { get; init; }
    public required string NrTelefonu { get; init; }
}
