using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Persistance.Entities.Commons;

public abstract record BaseEntity<TId> : ITimeTrackable where TId : struct
{
    public TId Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}

public abstract record BaseEntity : BaseEntity<Guid>;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        if (builder.Metadata.BaseType == null)
        {
            builder.HasKey(x => x.Id);
        }
    }
}