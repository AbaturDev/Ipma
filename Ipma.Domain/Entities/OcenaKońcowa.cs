namespace Ipma.Domain.Entities;

public record OcenaKońcowa : OcenaProjektu
{
    public required string RekomendacjaFinałowa { get; init; }
    public required double OstatecznaNotaPunktowa { get; init; }
}
