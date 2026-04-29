namespace Ipma.Domain.Entities;

public record RaportZWizyty : AudytowalnaEncja
{
    public required string KatalogOdpowiedziDlaJury { get; init; }
    public required DateOnly DataZłożeniaDokumentu { get; init; }
}
