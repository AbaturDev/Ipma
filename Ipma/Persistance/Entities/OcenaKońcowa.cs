using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record OcenaKońcowa : OcenaProjektu
{
    public required string RekomendacjaFinałowa { get; init; }
    public required double OstatecznaNotaPunktowa { get; init; }

    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;
}

public class OcenaKońcowaConfiguration : OcenaProjektuConfiguration<OcenaKońcowa>
{
    public override void Configure(EntityTypeBuilder<OcenaKońcowa> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Projekt)
            .WithOne(p => p.OcenaKońcowa)
            .HasForeignKey<OcenaKońcowa>(x => x.ProjektId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}