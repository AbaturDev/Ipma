using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities.Commons;

public abstract record KontoUżytkownika : BaseEntity
{
    public required string Login { get; init; }
    public required string Hasło { get; set; }
}

public class KontoUżytkownikaConfiguration : BaseEntityConfiguration<KontoUżytkownika>
{
    public override void Configure(EntityTypeBuilder<KontoUżytkownika> builder)
    {
        base.Configure(builder);
        
        builder.Property(x => x.Login).IsRequired();
        builder.Property(x => x.Hasło).IsRequired();

        builder.UseTptMappingStrategy();
    }
}