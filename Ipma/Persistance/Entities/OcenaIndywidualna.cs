using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record OcenaIndywidualna : OcenaProjektu
{
    public required bool CzyZatwierdzona { get; init; }

    public Guid ProjektId { get; set; }
    public Projekt Projekt { get; set; } = null!;

    public Guid AsesorId { get; set; }
    public Asesor Asesor { get; set; } = null!;
}

public class OcenaIndywidualnaConfiguration : BaseEntityConfiguration<OcenaIndywidualna>
{
    public override void Configure(EntityTypeBuilder<OcenaIndywidualna> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Asesor)
            .WithMany(a => a.OcenyIndywidualne)
            .HasForeignKey(x => x.AsesorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.Projekt)
            .WithMany(a => a.OcenyIndywidualne)
            .HasForeignKey(x => x.ProjektId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
