using Ipma.Domain.Entities.Commons;
using Ipma.Domain.Entities.Owned;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

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

        builder.OwnsOne(x => x.DaneOsobowe);
    }
}