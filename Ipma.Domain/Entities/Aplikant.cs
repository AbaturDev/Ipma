namespace Ipma.Domain.Entities;

public record Aplikant : DaneOsobowe
{
    // Kompozycja zamiast wielodziedziczenia
    public required Organizacja Organizacja { get; init; }
    public required DaneOsobowe DaneOsobowe { get; init; }

    public required bool StatusCzłonkaIPMA { get; init; }
    public ICollection<Projekt> Projekty { get; init; } = new List<Projekt>();
}
