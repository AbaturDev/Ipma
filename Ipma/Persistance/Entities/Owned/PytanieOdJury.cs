using Microsoft.EntityFrameworkCore;

namespace Ipma.Persistance.Entities.Owned;

[Owned]
public sealed record PytanieOdJury
{
    public required string Treść { get; set; }
}