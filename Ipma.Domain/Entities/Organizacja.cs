namespace Ipma.Domain.Entities;

public record Organizacja
{
    public required string NazwaOrganizacji { get; init; }
    public required string NumerNIP { get; init; }
    public string? SkrótNazwyOrganizacji { get; init; }
    public required string KodPocztowy { get; init; }
}
