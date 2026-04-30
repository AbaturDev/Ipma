using Ipma.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record RaportAplikacyjny : AudytowalnaEncja
{
    public required string WykazZałączników { get; init; }
    public required DateOnly DataDostarczeniaFizycznego { get; init; }
    
    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;
}

public class RaportAplikacyjnyConfiguration : BaseEntityConfiguration<RaportAplikacyjny>
{
    public override void Configure(EntityTypeBuilder<RaportAplikacyjny> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Projekt)
            .WithOne(p => p.RaportAplikacyjny)
            .HasForeignKey<RaportAplikacyjny>(x => x.ProjektId);
    }
}
