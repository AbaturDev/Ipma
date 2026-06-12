namespace Ipma.Persistance.Entities.Commons;

public abstract record OcenaProjektu : BaseEntity
{
    public required decimal WynikObszarLudzieICel { get; init; }
    public required decimal WynikObszarProcesyIZasoby { get; init; }
    public required decimal WynikObszarRezultaty { get; init; }
    public required string UzasadnienieOceniajacego { get; init; }
    public required DateOnly PlanowanaDataOpracowania { get; init; }
    public required bool CzyOcenaSpozniona { get; init; }
}