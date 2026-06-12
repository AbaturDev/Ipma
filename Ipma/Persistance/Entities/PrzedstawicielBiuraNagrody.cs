using Ipma.Persistance.Entities.Commons;
using Ipma.Persistance.Entities.Owned;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record PrzedstawicielBiuraNagrody : KontoUżytkownika
{
    public required DaneOsobowe DaneOsobowe { get; set; }
    public Guid BiuroNagrodyId { get; set; }

    public BiuroNagrody BiuroNagrody { get; set; } = null!;
}

public class PrzedstawicielBiuraNagrodyConfiguration : BaseEntityConfiguration<PrzedstawicielBiuraNagrody>
{
    public override void Configure(EntityTypeBuilder<PrzedstawicielBiuraNagrody> builder)
    {
        base.Configure(builder);

        builder.ToTable(nameof(PrzedstawicielBiuraNagrody));
        
        builder.OwnsOne(x => x.DaneOsobowe);
        
        builder.HasOne(x => x.BiuroNagrody)
            .WithMany(b => b.PrzedstawicieleBiuraNagrody)
            .HasForeignKey(x => x.BiuroNagrodyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}