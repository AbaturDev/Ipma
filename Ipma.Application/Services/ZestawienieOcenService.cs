using Ipma.Domain.Entities;
using Ipma.Domain.Enums;
using Ipma.Infrastructure;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Ipma.Application.Services;

public class ZestawienieOcenService
{
    private readonly IpmaDbContext _context;

    public ZestawienieOcenService(IpmaDbContext context)
    {
        _context = context;
    }

    // 1. Zwykłe logowanie do celów testowych
    public async Task<bool> ZalogujBanalnie(string login, string haslo)
    {
        return await _context.BiuraNagrody.AnyAsync(b => b.Login == login && b.Hasło == haslo);
    }

    // 2. Pobranie danych dla aktualnej edycji
    public async Task<List<Projekt>> PobierzZestawienieAktualnejEdycjiAsync()
    {
        return await _context.Projekty
            .Include(p => p.OcenaKońcowa)
            .Include(p => p.EdycjaKonkursu)
            .Where(p => p.EdycjaKonkursu.StatusRealizacji == StatusEdycji.Aktywna)
            .ToListAsync();
    }

    // 3. Generowanie PDF za pomocą QuestPDF
    public byte[] GenerujRaportPdf(List<Projekt> projekty)
    {
        QuestPDF.Settings.License = LicenseType.Community;

        // Pobieramy numer edycji z pierwszego projektu na liście (lub 1, jeśli lista jest pusta)
        int numerEdycji = projekty.FirstOrDefault()?.EdycjaKonkursu?.NumerEdycji ?? 1;

        var document = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                page.Header().Text($"Zestawienie ocen końcowych - edycja {numerEdycji}")
                    .SemiBold().FontSize(18).FontColor(Colors.Blue.Darken2);

                page.Content().PaddingVertical(1, Unit.Centimetre).Column(col =>
                {
                    foreach (var projekt in projekty)
                    {
                        col.Item().PaddingBottom(15).Border(1).BorderColor(Colors.Grey.Lighten2).Padding(10).Column(c =>
                        {
                            c.Item().Text($"Projekt: {projekt.NazwaPrzedsięwzięcia}").Bold().FontSize(14);
                            c.Item().Text($"Nota końcowa: {projekt.OcenaKońcowa?.OstatecznaNotaPunktowa} | Rekomendacja: {projekt.OcenaKońcowa?.RekomendacjaFinałowa}");
                            c.Item().Text($"Ludzie i Cel: {projekt.OcenaKońcowa?.WynikObszarLudzieICel} | Procesy: {projekt.OcenaKońcowa?.WynikObszarProcesyIZasoby} | Rezultaty: {projekt.OcenaKońcowa?.WynikObszarRezultaty}");
                            c.Item().Text($"Uzasadnienie: {projekt.OcenaKońcowa?.UzasadnienieOceniajacego}").Italic();
                        });
                    }
                });

                page.Footer().AlignRight().Text(text =>
                {
                    text.Span("strona ");
                    text.CurrentPageNumber();
                    text.Span(" z ");
                    text.TotalPages();
                });
            });
        });

        return document.GeneratePdf();
    }
}