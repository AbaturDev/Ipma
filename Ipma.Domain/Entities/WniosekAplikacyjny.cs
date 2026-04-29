namespace Ipma.Domain.Entities;

public record WniosekAplikacyjny : AudytowalnaEncja
{
    public required DateOnly DataWprowadzeniaDoSystemu { get; init; }
    public required bool FlagaZgodnościFormalnej { get; init; }
    public required string PowódOdrzucenia { get; init; }
    public required int NumerAplikacji { get; init; }
}
