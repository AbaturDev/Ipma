using Ipma.Persistance.Entities;
using Ipma.Persistance.Entities.Owned;
using Ipma.Persistance.Enums;
using Ipma.Services.PasswordHasher.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Persistance.Seeders;

public class DbSeeder
{
    private readonly IpmaDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public DbSeeder(IpmaDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task SeedAsync()
    {
        if (await _context.Użytkownicy.AnyAsync())
            return;

        var password = _passwordHasher.Hash("Test123!");

        var edycja = new EdycjaKonkursu
        {
            RokKalendarzowy = 2026,
            StatusRealizacji = StatusEdycji.WPrzygotowaniu,
            NumerEdycji = 1
        };

        var ekspert = new EkspertIpma
        {
            RokUkończeniaSzkoleńPeb = 2020,
            Status = StatusEkspertaIpma.Aktywny,
            FlagaKonfliktuInteresów = false,
            DaneOsobowe = new DaneOsobowe
            {
                Imie = "Anna",
                Nazwisko = "Nowak",
                AdresEmail = "asesor@test.pl",
                NrTelefonu = "987654321"
            }
        };

        _context.EdycjeKonkursu.Add(edycja);
        _context.EksperciIpma.Add(ekspert);
        await _context.SaveChangesAsync();

        var biuro = new BiuroNagrody
        {
            AdresKorespondencyjny = "ul. Testowa 1, 00-001 Warszawa",
            AdresEmail = "biuro@test.pl",
            EdycjaKonkursuId = edycja.Id
        };

        _context.BiuraNagrody.Add(biuro);
        await _context.SaveChangesAsync();

        var aplikant = new Aplikant
        {
            Login = "aplikant@test.pl",
            Hasło = password,
            StatusCzłonkaIpma = true,
            Organizacja = new Organizacja
            {
                NazwaOrganizacji = "Firma Testowa Sp. z o.o.",
                NumerNip = "1234567890",
                SkrótNazwyOrganizacji = "FT",
                KodPocztowy = "00-001"
            },
            DaneOsobowe = new DaneOsobowe
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                AdresEmail = "aplikant@test.pl",
                NrTelefonu = "123456789"
            }
        };

        var asesor = new Asesor
        {
            Login = "asesor@test.pl",
            Hasło = password,
            FlagaUprawnieńZarządczych = true,
            EkspertIpmaId = ekspert.Id
        };

        var członekJury = new CzłonekJury
        {
            Login = "jury@test.pl",
            Hasło = password,
            AfiliacjaNaukowaLubBiznesowa = "Politechnika Warszawska",
            DaneOsobowe = new DaneOsobowe
            {
                Imie = "Piotr",
                Nazwisko = "Wiśniewski",
                AdresEmail = "jury@test.pl",
                NrTelefonu = "555666777"
            }
        };

        var przedstawiciel = new PrzedstawicielBiuraNagrody
        {
            Login = "biuro@test.pl",
            Hasło = password,
            BiuroNagrodyId = biuro.Id,
            DaneOsobowe = new DaneOsobowe
            {
                Imie = "Maria",
                Nazwisko = "Zielińska",
                AdresEmail = "biuro@test.pl",
                NrTelefonu = "111222333"
            }
        };

        _context.Aplikanci.Add(aplikant);
        _context.Asesorzy.Add(asesor);
        _context.CzłonkowieJury.Add(członekJury);
        _context.PrzedstawicieleBiuraNagrody.Add(przedstawiciel);

        await _context.SaveChangesAsync();
    }
}
