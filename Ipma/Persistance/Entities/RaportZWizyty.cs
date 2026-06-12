using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record RaportZWizyty : AudytowalnaEncja
{
    public required string KatalogOdpowiedziDlaJury { get; init; }
    public required DateOnly DataZłożeniaDokumentu { get; init; }
    
    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;
}

public class RaportZWizytyConfiguration : AudytowalnaEncjaConfiguration<RaportZWizyty>
{
    public override void Configure(EntityTypeBuilder<RaportZWizyty> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Projekt)
            .WithOne(p => p.RaportZWizyty)
            .HasForeignKey<RaportZWizyty>(x => x.ProjektId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
    
