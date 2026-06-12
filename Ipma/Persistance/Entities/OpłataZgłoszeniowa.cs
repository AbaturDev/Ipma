using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities;

public sealed record OpłataZgłoszeniowa : BaseEntity
{
    public required decimal KwotaDoZapłatyNetto { get; init; }
    public required DateOnly DataRejestracjiWpłaty { get; init; }
    public required string StatusTransakcji { get; init; }

    public Guid WniosekAplikacyjnyId { get; set; }
    public WniosekAplikacyjny WniosekAplikacyjny { get; set; } = null!;
}

public class OpłataZgłoszeniowaConfiguration : BaseEntityConfiguration<OpłataZgłoszeniowa>
{
    public override void Configure(EntityTypeBuilder<OpłataZgłoszeniowa> builder)
    {
        base.Configure(builder);

        builder.HasOne(x => x.WniosekAplikacyjny)
            .WithOne(p => p.OpłataZgłoszeniowa)
            .HasForeignKey<OpłataZgłoszeniowa>(x => x.WniosekAplikacyjnyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}