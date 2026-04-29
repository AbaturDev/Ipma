namespace Ipma.Domain.Entities;

public abstract record KontoUżytkownika
{
    public required string Login { get; init; }
    public required string HasłoKryptograficzne { get; init; }
    public required bool StatusKonta { get; init; }
    public required RolaKonta Rola { get; init; }
}
