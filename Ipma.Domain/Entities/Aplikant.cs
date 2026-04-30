using Ipma.Domain.Entities.Commons;
using Ipma.Domain.Entities.Owned;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record Aplikant : KontoUżytkownika
{
    public required bool StatusCzłonkaIpma { get; set; }
    
    public required Organizacja Organizacja { get; set; }
    public required DaneOsobowe DaneOsobowe { get; set; }
    
    public ICollection<Projekt> Projekty { get; set; } = new List<Projekt>();
}

public class AplikantConfiguration : BaseEntityConfiguration<Aplikant>
{
    public override void Configure(EntityTypeBuilder<Aplikant> builder)
    {
        base.Configure(builder);

        builder.OwnsOne(x => x.Organizacja);
        builder.OwnsOne(x => x.DaneOsobowe);
    }
}
