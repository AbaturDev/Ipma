using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record Asesor : KontoUżytkownika
{
    public required string FlagaUprawnieńZarządczych { get; init; }

    public required Guid EkspertIpmaId { get; set; }
    public EkspertIpma EkspertIpma { get; set; } = null!;

    public ICollection<OcenaIndywidualna> OcenyIndywidualne { get; set; } = new List<OcenaIndywidualna>();
    public ICollection<Projekt> ProjektyNadzorowane { get; set; } = new List<Projekt>();
}

public class AsesorConfiguration : BaseEntityConfiguration<Asesor>
{
    public override void Configure(EntityTypeBuilder<Asesor> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(Asesor));
        
        builder.HasOne(x => x.EkspertIpma)
            .WithOne(e => e.Asesor)
            .HasForeignKey<Asesor>(x => x.EkspertIpmaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
