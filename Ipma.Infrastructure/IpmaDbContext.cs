using Ipma.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ipma.Infrastructure;

public class IpmaDbContext : DbContext
{
    public DbSet<KontoUżytkownika> KontaUżytkowników { get; set; }
    public DbSet<AudytowalnaEncja> AudytowalneEncje { get; set; }
    public DbSet<OcenaProjektu> OcenyProjektu { get; set; }
    public DbSet<Aplikant> Aplikanci { get; set; }
    public DbSet<Asesor> Asesorzy { get; set; }
    public DbSet<CzłonekJury> CzłonkowieJury { get; set; }
    public DbSet<Kategoria> Kategorie { get; set; }
    public DbSet<Organizacja> Organizacje { get; set; }
    public DbSet<Projekt> Projekty { get; set; }
    public DbSet<EdycjaKonkursu> EdycjeKonkursu { get; set; }
    public DbSet<Harmonogram> Harmonogramy { get; set; }
    public DbSet<WniosekAplikacyjny> WnioskiAplikacyjne { get; set; }
    public DbSet<RaportZWizyty> RaportyZWizyty { get; set; }
    public DbSet<RaportAplikacyjny> RaportyAplikacyjne { get; set; }
    public DbSet<OcenaKońcowa> OcenyKońcowe { get; set; }
    public DbSet<OcenaWstępna> OcenyWstępne { get; set; }
    public DbSet<OcenaIndywidualna> OcenyIndywidualne { get; set; }
    public DbSet<EkspertIPMA> EksperciIPMA { get; set; }
    public DbSet<BiuroNagrody> BiuraNagrody { get; set; }
    public DbSet<UmowaWspółpracy> UmowyWspółpracy { get; set; }
    public DbSet<OpłataZgłoszeniowa> OpłatyZgłoszeniowe { get; set; }

    public IpmaDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}