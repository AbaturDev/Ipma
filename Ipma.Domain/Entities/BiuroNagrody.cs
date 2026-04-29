namespace Ipma.Domain.Entities;

public record BiuroNagrody
{
    public required string AdresKorespondencyjny { get; init; }
    public required string AdresEmail { get; init; }
}
