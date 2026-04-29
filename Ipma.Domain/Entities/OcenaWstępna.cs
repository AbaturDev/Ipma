namespace Ipma.Domain.Entities;

public record OcenaWstępna : OcenaProjektu
{
    public required decimal SkonsolidowanyWynikPunktowy { get; init; }
    public required bool CzyOsiągniętoKonsensus { get; init; }
}
