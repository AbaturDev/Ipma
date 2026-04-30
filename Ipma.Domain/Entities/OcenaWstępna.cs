using Ipma.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record OcenaWstępna : OcenaProjektu
{
    public required decimal SkonsolidowanyWynikPunktowy { get; init; }
    public required bool CzyOsiągniętoKonsensus { get; init; }

    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;
}

public class OcenaWstępnaConfiguration : BaseEntityConfiguration<OcenaWstępna>
{
    public override void Configure(EntityTypeBuilder<OcenaWstępna> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Projekt)
            .WithOne(p => p.OcenaWstępna)
            .HasForeignKey<OcenaWstępna>(x => x.ProjektId);
    }
}