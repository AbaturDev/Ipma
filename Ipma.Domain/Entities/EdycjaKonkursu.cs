namespace Ipma.Domain.Entities;

public record EdycjaKonkursu
{
    public required int RokKalendarzowy { get; init; }
    public required StatusEdycji StatusRealizacji { get; init; }
    public required int NumerEdycji { get; init; }
    public ICollection<CzłonekJury> CzłonkowieJury { get; init; } = new List<CzłonekJury>();
    public CzłonekJury? Przewodniczący { get; init; }
    public ICollection<Kategoria> Kategorie { get; init; } = new List<Kategoria>();
}
