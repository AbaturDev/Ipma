using Microsoft.EntityFrameworkCore;

namespace Ipma.Persistance.Entities.Owned;

[Owned]
public sealed record Organizacja
{
    public required string NazwaOrganizacji { get; init; }
    public required string NumerNip { get; init; }
    public string? SkrótNazwyOrganizacji { get; init; }
    public required string KodPocztowy { get; init; }
}
