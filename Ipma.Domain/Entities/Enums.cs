namespace Ipma.Domain.Entities;

public enum RolaKonta
{
    Administrator,
    Asesor,
    Czlonek_Jury,
    Biuro_Nagrody,
    Aplikant
}

public enum StopienNagrody
{
    Brak,
    Finalista,
    Zwyciezca,
    Wyroznienie
}

public enum StatusEdycji
{
    Planowana,
    Otwarta,
    Zamknieta,
    Zakonczona
}
