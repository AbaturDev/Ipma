using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities.Commons;

public abstract record AudytowalnaEncja : BaseEntity
{
    public Guid UtworzonyPrzezId { get; set; }
    public Guid? ZmodyfikowanyPrzezId { get; set; }
    
    public KontoUżytkownika UtworzonyPrzez { get; set; } = null!;
    public KontoUżytkownika? ZmodyfikowanyPrzez { get; set; }
}

public abstract class AudytowalnaEncjaConfiguration<T> : BaseEntityConfiguration<T> where T : AudytowalnaEncja
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.UtworzonyPrzez)
            .WithMany()
            .HasForeignKey(x => x.UtworzonyPrzezId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ZmodyfikowanyPrzez)
            .WithMany()
            .HasForeignKey(x => x.ZmodyfikowanyPrzezId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}