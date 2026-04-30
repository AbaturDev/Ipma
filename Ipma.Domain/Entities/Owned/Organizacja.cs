using Microsoft.EntityFrameworkCore;

namespace Ipma.Domain.Entities.Owned;

[Owned]
public abstract record Organizacja
{
    public required string NazwaOrganizacji { get; init; }
    public required string NumerNip { get; init; }
    public string? SkrótNazwyOrganizacji { get; init; }
    public required string KodPocztowy { get; init; }
}
