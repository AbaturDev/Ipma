namespace Ipma.Domain.Entities;

public record EkspertIPMA : DaneOsobowe
{
    public required int RokUkończeniaSzkoleńPEB { get; init; }
    public required string StatusDostępności { get; init; }
    public required bool FlagaKonfliktuInteresów { get; init; }
}
