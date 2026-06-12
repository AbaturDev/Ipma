using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record BiuroNagrody : BaseEntity
{
    public required string AdresKorespondencyjny { get; set; }
    public required string AdresEmail { get; set; }

    public required Guid EdycjaKonkursuId { get; set; }
    public EdycjaKonkursu EdycjaKonkursu { get; set; } = null!;

    public ICollection<PrzedstawicielBiuraNagrody> PrzedstawicieleBiuraNagrody { get; set; } = new List<PrzedstawicielBiuraNagrody>();
}

public class BiuroNagrodyConfiguration : BaseEntityConfiguration<BiuroNagrody>
{
    public override void Configure(EntityTypeBuilder<BiuroNagrody> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.EdycjaKonkursu)
            .WithOne(e => e.BiuroNagrody)
            .HasForeignKey<BiuroNagrody>(x => x.EdycjaKonkursuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}