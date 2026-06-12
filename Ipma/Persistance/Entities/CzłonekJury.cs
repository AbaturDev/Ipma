using Ipma.Persistance.Entities.Commons;
using Ipma.Persistance.Entities.Owned;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record CzłonekJury : KontoUżytkownika
{
    public required string AfiliacjaNaukowaLubBiznesowa { get; init; }

    public required DaneOsobowe DaneOsobowe { get; init; }

    public ICollection<EdycjaKonkursu> OcenianeKonkursy { get; set; } = new List<EdycjaKonkursu>();
    public ICollection<EdycjaKonkursu> PrzewodzoneKonkursy { get; set; } = new List<EdycjaKonkursu>();
}

public class CzłonekJuryConfiguration : BaseEntityConfiguration<CzłonekJury>
{
    public override void Configure(EntityTypeBuilder<CzłonekJury> builder)
    {
        base.Configure(builder);

        builder.ToTable("CzlonekJury");
        
        builder.OwnsOne(x => x.DaneOsobowe);
    }
}