namespace Ipma.Domain.Entities;

public record CzłonekJury : KontoUżytkownika
{
    // Kompozycja dla DaneOsobowe
    public required DaneOsobowe DaneOsobowe { get; init; }
    public required string AfiliacjaNaukowaLubBiznesowa { get; init; }
}
