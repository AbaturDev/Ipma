namespace Ipma.Domain.Entities;

public record OcenaIndywidualna : OcenaProjektu
{
    public required bool CzyZatwierdzona { get; init; }
}
