namespace Ipma.Domain.Entities;

public record RaportAplikacyjny : AudytowalnaEncja
{
    public required string WykazZałączników { get; init; }
    public required DateOnly DataDostarczeniaFizycznego { get; init; }
}
