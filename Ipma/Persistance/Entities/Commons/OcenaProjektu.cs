using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities.Commons;

public abstract record OcenaProjektu : BaseEntity
{
    public required decimal WynikObszarLudzieICel { get; init; }
    public required decimal WynikObszarProcesyIZasoby { get; init; }
    public required decimal WynikObszarRezultaty { get; init; }
    public required string UzasadnienieOceniajacego { get; init; }
    public required DateOnly PlanowanaDataOpracowania { get; init; }
    public required bool CzyOcenaSpozniona { get; init; }
}

public abstract class OcenaProjektuConfiguration<T> : BaseEntityConfiguration<T> where T : OcenaProjektu
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.WynikObszarLudzieICel)
            .HasPrecision(18, 2);

        builder.Property(x => x.WynikObszarProcesyIZasoby)
            .HasPrecision(18, 2);

        builder.Property(x => x.WynikObszarRezultaty)
            .HasPrecision(18, 2);
    }
}