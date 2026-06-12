using Microsoft.EntityFrameworkCore;

namespace Ipma.Persistance.Entities.Owned;

[Owned]
public sealed record DaneOsobowe
{
    public required string Imie { get; init; }
    public required string Nazwisko { get; init; }
    public required string AdresEmail { get; init; }
    public required string NrTelefonu { get; init; }
}
