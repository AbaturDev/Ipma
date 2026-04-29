namespace Ipma.Domain.Entities;

public abstract record DaneOsobowe
{
    public required string Imie { get; init; }
    public required string Nazwisko { get; init; }
    public required string AdresEmail { get; init; }
    public required string NrTelefonu { get; init; }
}
