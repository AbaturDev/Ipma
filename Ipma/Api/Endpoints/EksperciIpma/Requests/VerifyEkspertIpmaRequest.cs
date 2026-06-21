using Ipma.Persistance.Enums;

namespace Ipma.Api.Endpoints.EksperciIpma.Requests;

public sealed record VerifyEkspertIpmaRequest
{
    public required StatusEkspertaIpma Status { get; init; }
}
