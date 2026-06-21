using Ipma.Api.Endpoints.EksperciIpma.Dtos;

namespace Ipma.Api.Endpoints.EksperciIpma.Responses;

public sealed record ListEkspertIpmaResponse
{
    public required ICollection<EkspertIpmaDto> EkspertIpmas { get; init; } = new List<EkspertIpmaDto>();
    public required int Count { get; init; }
}
