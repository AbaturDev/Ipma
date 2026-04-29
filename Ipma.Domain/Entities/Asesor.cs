namespace Ipma.Domain.Entities;

public record Asesor : KontoUżytkownika
{
    public required string FlagaUprawnieńZarządczych { get; init; }
}
