using Ipma.Domain.Entities.Commons;
using Ipma.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record EdycjaKonkursu : BaseEntity
{
    public required int RokKalendarzowy { get; init; }
    public required StatusEdycji StatusRealizacji { get; init; }
    public required int NumerEdycji { get; init; }

    public Guid? PrzewodniczącyId { get; set; }
    public CzłonekJury? Przewodniczący { get; init; }

    public Harmonogram Harmonogram { get; set; } = null!;
    public BiuroNagrody BiuroNagrody { get; set; } = null!;
    
    public ICollection<Projekt> Projekty { get; init; } = new List<Projekt>();
    public ICollection<CzłonekJury> CzłonkowieJury { get; init; } = new List<CzłonekJury>();
    public ICollection<Kategoria> Kategorie { get; init; } = new List<Kategoria>();
}

public class EdycjaKonkursuConfiguration : BaseEntityConfiguration<EdycjaKonkursu>
{
    public override void Configure(EntityTypeBuilder<EdycjaKonkursu> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.Przewodniczący)
            .WithMany(c => c.PrzewodzoneKonkursy)
            .HasForeignKey(x => x.PrzewodniczącyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.CzłonkowieJury)
            .WithMany(c => c.OcenianeKonkursy);

        builder.HasMany(x => x.Kategorie)
            .WithMany(k => k.EdycjeKonkursu);
    }
}