namespace Ipma.Domain.Entities;

public record Projekt : AudytowalnaEncja
{
    public required string NazwaPrzedsięwzięcia { get; init; }
    public required int CzasTrwaniaWMiesiącach { get; init; }
    public required int WielkośćZespołu { get; init; }
    public required int LiczbaPodwykonawców { get; init; }
    public required DateOnly DataUkończenia { get; init; }
    public required string StanKwalifikacji { get; init; }
    public required string MiejsceWizytyStudyjnej { get; init; }
    public ICollection<string> PytaniaOdJury { get; init; } = new List<string>();
    public required StopienNagrody KategoriaWyróżnienia { get; init; }
    public decimal? ŚredniaOcenaCzłonkówJury { get; init; }

    public ICollection<Asesor> ZespółAsesorów { get; init; } = new List<Asesor>();
    public Asesor? AsesorWiodący { get; init; }
}
