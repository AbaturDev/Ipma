using Ipma.Domain.Entities.Commons;

namespace Ipma.Domain.Entities;

public sealed record UmowaWspółpracy : BaseEntity
{
    public required DateOnly DataZawarciaKontraktu { get; init; }
    public required string ZakresPowierzonychZadań { get; init; }
    public required bool KlauzulaPoufności { get; init; }

    public EkspertIpma EkspertIpma { get; set; } = null!;
}
