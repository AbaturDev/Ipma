using Microsoft.EntityFrameworkCore;

namespace Ipma.Domain.Entities.Owned;

[Owned]
public sealed record PytanieOdJury
{
    public required string Treść { get; set; }
}