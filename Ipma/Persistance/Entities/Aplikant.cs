using Ipma.Persistance.Entities.Commons;
using Ipma.Persistance.Entities.Owned;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

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
        
        builder.ToTable(nameof(Aplikant));

        builder.OwnsOne(x => x.Organizacja);
        builder.OwnsOne(x => x.DaneOsobowe);
    }
}
