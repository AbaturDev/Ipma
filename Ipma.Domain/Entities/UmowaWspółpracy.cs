namespace Ipma.Domain.Entities;

public record UmowaWspółpracy
{
    public required DateOnly DataZawarciaKontraktu { get; init; }
    public required string ZakresPowierzonychZadań { get; init; }
    public required bool KlauzulaPoufności { get; init; }
}
