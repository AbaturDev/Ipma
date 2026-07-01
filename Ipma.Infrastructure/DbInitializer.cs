using Ipma.Domain.Entities;
using Ipma.Domain.Entities.Owned;
using Ipma.Domain.Enums;

namespace Ipma.Infrastructure;

public static class DbInitializer
{
    public static void SeedData(IpmaDbContext context)
    {
        context.Database.EnsureCreated(); // Upewnia się, że baza i tabele istnieją

        // Zabezpieczenie przed ponownym seedowaniem, jeśli dane już są w bazie
        if (context.EdycjeKonkursu.Any()) return;

        // 1. ZMOKOWANA EDYCJA KONKURSU (Tworzymy jako pierwszą, bo Biuro jej wymaga)
        var edycja = new EdycjaKonkursu
        {
            Id = Guid.NewGuid(),
            RokKalendarzowy = DateTime.Now.Year,
            NumerEdycji = 1,
            StatusRealizacji = StatusEdycji.Aktywna
        };
        context.EdycjeKonkursu.Add(edycja);

        // 2. ZMOKOWANE KONTO UŻYTKOWNIKA (Biuro Nagrody)
        var biuro = new BiuroNagrody
        {
            Id = Guid.NewGuid(),
            Login = "admin_biuro",
            Hasło = "haslo123", // Hasło podpinane z klasy abstrakcyjnej KontoUżytkownika
            StatusKonta = true,
            Rola = RolaKonta.BiuroNagrody,
            AdresKorespondencyjny = "ul. Wybrzeże Wyspiańskiego 27, Wrocław",
            AdresEmail = "biuro@ipma.pl",
            EdycjaKonkursuId = edycja.Id // Powiązanie z wcześniej utworzoną edycją
        };
        context.BiuraNagrody.Add(biuro);

        // 3. ZMOKOWANY APLIKANT Z TYPAMI WŁASNYMI
        var aplikant = new Aplikant
        {
            Id = Guid.NewGuid(),
            Login = "aplikant_test",
            Hasło = "haslo123",
            StatusKonta = true,
            Rola = RolaKonta.Aplikant,
            StatusCzłonkaIpma = true,
            // Właściwości pobrane na podstawie diagramu modelu PIM
            DaneOsobowe = new DaneOsobowe
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                AdresEmail = "jan.kowalski@firma.pl",
                NrTelefonu = "123456789"
            },
            Organizacja = new Organizacja
            {
                NazwaOrganizacji = "Tech-Soft Sp. z o.o.",
                NumerNip = "1234567890",
                SkrótNazwyOrganizacji = "TechSoft",
                KodPocztowy = "50-370"
            }
        };
        context.Aplikanci.Add(aplikant);

        // 4. KATEGORIA
        var katIT = new Kategoria { Id = Guid.NewGuid(), Nazwa = "IT" };
        var katBudownictwo = new Kategoria { Id = Guid.NewGuid(), Nazwa = "Budownictwo" };
        context.Kategorie.AddRange(katIT, katBudownictwo);

        // 5. LISTA 10 PROJEKTÓW
        var projekty = new List<Projekt>
        {
            UtworzProjekt("System CRM dla Banku", 95.5, "Zwycięzca", edycja.Id, katIT.Id, aplikant.Id),
            UtworzProjekt("Wdrożenie platformy e-commerce", 88.0, "Srebrny Finalista", edycja.Id, katIT.Id, aplikant.Id),
            UtworzProjekt("Migracja do chmury obliczeniowej", 84.5, "Brązowy Finalista", edycja.Id, katIT.Id, aplikant.Id),
            UtworzProjekt("Aplikacja mobilna M-Obywatel", 79.0, "Finalista", edycja.Id, katIT.Id, aplikant.Id),
            UtworzProjekt("Modernizacja infrastruktury sieciowej", 65.5, "Uczestnik", edycja.Id, katIT.Id, aplikant.Id),

            UtworzProjekt("Budowa osiedla Zielona Dolina", 92.0, "Zwycięzca", edycja.Id, katBudownictwo.Id, aplikant.Id),
            UtworzProjekt("Rewitalizacja dworca PKP", 89.5, "Srebrny Finalista", edycja.Id, katBudownictwo.Id, aplikant.Id),
            UtworzProjekt("Most obwodnicy południowej", 81.0, "Brązowy Finalista", edycja.Id, katBudownictwo.Id, aplikant.Id),
            UtworzProjekt("Budowa fabryki baterii EV", 75.5, "Finalista", edycja.Id, katBudownictwo.Id, aplikant.Id),
            UtworzProjekt("Rozbudowa terminala lotniczego", 55.0, "Uczestnik", edycja.Id, katBudownictwo.Id, aplikant.Id)
        };
        context.Projekty.AddRange(projekty);

        context.SaveChanges();
    }

    // Metoda pomocnicza, żeby nie kopiować tego samego kodu 10 razy
    private static Projekt UtworzProjekt(string nazwa, double nota, string rekomendacja, Guid edycjaId, Guid kategoriaId, Guid aplikantId)
    {
        // Delikatna matematyka, żeby obszary sumowały się mniej więcej do noty całkowitej
        decimal obszar1 = (decimal)(nota * 0.3);
        decimal obszar2 = (decimal)(nota * 0.4);
        decimal obszar3 = (decimal)(nota - (double)obszar1 - (double)obszar2);

        return new Projekt
        {
            Id = Guid.NewGuid(),
            NazwaPrzedsięwzięcia = nazwa,
            CzasTrwaniaWMiesiącach = 12,
            WielkośćZespołu = 15,
            LiczbaPodwykonawców = 3,
            DataUkończenia = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)),
            StanKwalifikacji = "Zakwalifikowany",
            MiejsceWizytyStudyjnej = "Wrocław",
            EdycjaKonkursuId = edycjaId,
            KategoriaId = kategoriaId,
            AplikantId = aplikantId,
            UtworzonyPrzezId = aplikantId,
            OcenaKońcowa = new OcenaKońcowa
            {
                Id = Guid.NewGuid(),
                OstatecznaNotaPunktowa = nota,
                RekomendacjaFinałowa = rekomendacja,
                WynikObszarLudzieICel = Math.Round(obszar1, 2),
                WynikObszarProcesyIZasoby = Math.Round(obszar2, 2),
                WynikObszarRezultaty = Math.Round(obszar3, 2),
                UzasadnienieOceniajacego = $"Projekt zasługuje na miano: {rekomendacja}. Wykazał się bardzo dobrą organizacją.",
                PlanowanaDataOpracowania = DateOnly.FromDateTime(DateTime.Now),
                CzyOcenaSpozniona = false
            }
        };
    }
}