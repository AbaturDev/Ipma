using Ipma.Domain.Enums;

namespace Ipma.Domain.Entities.Commons;

public abstract record KontoUżytkownika : BaseEntity
{
    public required string Login { get; init; }
    public required string Hasło { get; set; }
    public required bool StatusKonta { get; set; }
    public required RolaKonta Rola { get; init; }
}
