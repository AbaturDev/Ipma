namespace Ipma.Domain.Entities;

public abstract record AudytowalnaEncja
{
    public required KontoUżytkownika UtworzonyPrzez { get; init; }
    public required DateTime DataUtworzenia { get; init; }
    public KontoUżytkownika? ZmodyfikowanyPrzez { get; init; }
    public DateTime? DataOstatniejModyfikacji { get; init; }
}
