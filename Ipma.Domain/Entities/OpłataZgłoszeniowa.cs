namespace Ipma.Domain.Entities;

public record OpłataZgłoszeniowa
{
    public required decimal KwotaDoZapłatyNetto { get; init; }
    public required DateOnly DataRejestracjiWpłaty { get; init; }
    public required string StatusTransakcji { get; init; }
}
