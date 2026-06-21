using Ipma.Persistance.Entities.Commons;
using Ipma.Persistance.Entities.Owned;
using Ipma.Persistance.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record EkspertIpma : BaseEntity
{
    public int? RokUkończeniaSzkoleńPeb { get; set; }
    public required StatusEkspertaIpma Status { get; set; }
    public required bool FlagaKonfliktuInteresów { get; set; }

    public required DaneOsobowe DaneOsobowe { get; set; }

    public Guid? UmowaWspółpracyId { get; set; }
    public UmowaWspółpracy? UmowaWspółpracy { get; set; }
    public Asesor? Asesor { get; set; }
}

public class EkspertIpmaConfiguration : BaseEntityConfiguration<EkspertIpma>
{
    public override void Configure(EntityTypeBuilder<EkspertIpma> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.DaneOsobowe);
        
        builder.HasOne(x => x.UmowaWspółpracy)
            .WithOne(u => u.EkspertIpma)
            .HasForeignKey<EkspertIpma>(x => x.UmowaWspółpracyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
