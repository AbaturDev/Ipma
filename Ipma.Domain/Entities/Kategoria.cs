namespace Ipma.Domain.Entities;

public record Kategoria
{
    public required string Nazwa { get; init; }
    public ICollection<EdycjaKonkursu> EdycjeKonkursu { get; init; } = new List<EdycjaKonkursu>();
    public ICollection<Projekt> Projekty { get; init; } = new List<Projekt>();
}