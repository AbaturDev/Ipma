namespace Ipma.Domain.Entities;

public record Harmonogram
{
    public required DateOnly DataOtwarciaAplikacji { get; init; }
    public required DateOnly DataZamknięciaAplikacji { get; init; }
    public required DateOnly TerminWizytStudyjnych { get; init; }
    public required DateOnly DataGaliFinałowej { get; init; }
    public required DateOnly DataWebinariumAplikantow { get; init; }
    public required DateOnly DataWebinariumAsesorow { get; init; }
    public required DateOnly DataWebinariumAsesorowWiodacych { get; init; }
    public required DateOnly DataPierwszegoPosiedzeniaJury { get; init; }
    public required DateOnly DataDrugiegoPosiedzeniaJury { get; init; }
}
