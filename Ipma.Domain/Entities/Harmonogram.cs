using Ipma.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record Harmonogram : BaseEntity
{
    public required DateOnly DataOtwarciaAplikacji { get; set; }
    public required DateOnly DataZamknięciaAplikacji { get; set; }
    public required DateOnly TerminWizytStudyjnych { get; set; }
    public required DateOnly DataGaliFinałowej { get; set; }
    public required DateOnly DataWebinariumAplikantow { get; set; }
    public required DateOnly DataWebinariumAsesorow { get; set; }
    public required DateOnly DataWebinariumAsesorowWiodacych { get; set; }
    public required DateOnly DataPierwszegoPosiedzeniaJury { get; set; }
    public required DateOnly DataDrugiegoPosiedzeniaJury { get; set; }

    public Guid EdycjaKonkursuId { get; set; }
    public EdycjaKonkursu EdycjaKonkursu { get; set; } = null!;
}

public class HarmonogramConfiguration : BaseEntityConfiguration<Harmonogram>
{
    public override void Configure(EntityTypeBuilder<Harmonogram> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.EdycjaKonkursu)
            .WithOne(e => e.Harmonogram)
            .HasForeignKey<Harmonogram>(x => x.EdycjaKonkursuId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}