using Ipma.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record WniosekAplikacyjny : AudytowalnaEncja
{
    public required DateOnly DataWprowadzeniaDoSystemu { get; init; }
    public required bool FlagaZgodnościFormalnej { get; init; }
    public required string PowódOdrzucenia { get; init; }
    public required int NumerAplikacji { get; init; }

    public OpłataZgłoszeniowa? OpłataZgłoszeniowa { get; set; }
    
    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;
}

public class WniosekAplikacyjnyConfiguration : AudytowalnaEncjaConfiguration<WniosekAplikacyjny>
{
    public override void Configure(EntityTypeBuilder<WniosekAplikacyjny> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Projekt)
            .WithOne(p => p.WniosekAplikacyjny)
            .HasForeignKey<WniosekAplikacyjny>(x => x.ProjektId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}