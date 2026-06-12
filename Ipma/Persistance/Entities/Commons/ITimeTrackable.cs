namespace Ipma.Persistance.Entities.Commons;

public interface ITimeTrackable
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}