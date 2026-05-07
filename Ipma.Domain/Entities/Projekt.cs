using Ipma.Domain.Entities.Commons;
using Ipma.Domain.Entities.Owned;
using Ipma.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ipma.Domain.Entities;

public sealed record Projekt : AudytowalnaEncja
{
    public required string NazwaPrzedsięwzięcia { get; set; }
    public required int CzasTrwaniaWMiesiącach { get; set; }
    public required int WielkośćZespołu { get; set; }
    public required int LiczbaPodwykonawców { get; set; }
    public required DateOnly DataUkończenia { get; set; }
    public required string StanKwalifikacji { get; set; }
    public required string MiejsceWizytyStudyjnej { get; set; }
    public StopienNagrody KategoriaWyróżnienia { get; set; } = StopienNagrody.Uczestnik;
    public decimal? ŚredniaOcenaCzłonkówJury { get; set; }

    public Guid AplikantId { get; set; }
    public Aplikant Aplikant { get; set; } = null!;

    public Guid KategoriaId { get; set; }
    public Kategoria Kategoria { get; set; } = null!;
    
    public Guid? AsesorWiodącyId { get; set; }
    public Asesor? AsesorWiodący { get; set; }

    public Guid EdycjaKonkursuId { get; set; }
    public EdycjaKonkursu EdycjaKonkursu { get; set; } = null!;

    public WniosekAplikacyjny WniosekAplikacyjny { get; set; } = null!;
    public OcenaKońcowa? OcenaKońcowa { get; set; }
    public OcenaWstępna? OcenaWstępna { get; set; }
    public RaportZWizyty? RaportZWizyty { get; set; }
    public RaportAplikacyjny? RaportAplikacyjny { get; set; }
    
    public ICollection<PytanieOdJury> PytaniaOdJury { get; set; } = new List<PytanieOdJury>();
    public ICollection<OcenaIndywidualna> OcenyIndywidualne { get; set; } = new List<OcenaIndywidualna>();
}

public class ProjektConfiguration : AudytowalnaEncjaConfiguration<Projekt>
{
    public override void Configure(EntityTypeBuilder<Projekt> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ŚredniaOcenaCzłonkówJury)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.EdycjaKonkursu)
            .WithMany(e => e.Projekty)
            .HasForeignKey(x => x.EdycjaKonkursuId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Kategoria)
            .WithMany(e => e.Projekty)
            .HasForeignKey(x => x.KategoriaId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.HasOne(x => x.AsesorWiodący)
            .WithMany(a => a.ProjektyNadzorowane)
            .HasForeignKey(x => x.AsesorWiodącyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Aplikant)
            .WithMany(a => a.Projekty)
            .HasForeignKey(x => x.AplikantId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.OwnsMany(x => x.PytaniaOdJury);
        
        builder.OwnsMany(x => x.PytaniaOdJury, b =>
        {
            b.WithOwner().HasForeignKey("ProjektId");
            b.Property<Guid>("Id");
            b.HasKey("Id");
        });
    }
}