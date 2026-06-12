using Ipma.Persistance.Entities.Commons;

namespace Ipma.Persistance.Entities;

public sealed record Kategoria : BaseEntity
{
    public required string Nazwa { get; init; }
    
    public ICollection<EdycjaKonkursu> EdycjeKonkursu { get; init; } = new List<EdycjaKonkursu>();
    public ICollection<Projekt> Projekty { get; init; } = new List<Projekt>();
}
