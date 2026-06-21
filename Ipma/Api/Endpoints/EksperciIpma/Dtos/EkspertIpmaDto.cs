using Ipma.Persistance.Enums;

namespace Ipma.Api.Endpoints.EksperciIpma.Dtos;

public sealed record EkspertIpmaDto
{
    public required Guid Id { get; init; }
    public required DateTimeOffset CreatedAt { get; init; }
    public required DateTimeOffset UpdatedAt { get; init; }
    public int? RokUkończeniaSzkoleńPeb { get; init; }
    public required StatusEkspertaIpma Status { get; init; }
    public required bool FlagaKonfliktuInteresów { get; init; }
    public required string Imie { get; init; }
    public required string Nazwisko { get; init; }
    public required string AdresEmail { get; init; }
    public required string NrTelefonu { get; init; }
}