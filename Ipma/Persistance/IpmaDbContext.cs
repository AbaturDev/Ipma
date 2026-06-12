using Ipma.Persistance.Entities;
using Ipma.Persistance.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ipma.Persistance;

public sealed class IpmaDbContext : DbContext
{
    private readonly TimeProvider _timeProvider;
    
    public IpmaDbContext(DbContextOptions options, TimeProvider timeProvider) : base(options)
    {
        _timeProvider = timeProvider;
        
        ChangeTracker.StateChanged += UpdateTimestamps;
        ChangeTracker.Tracked += UpdateTimestamps;
    }
    
    public DbSet<Aplikant> Aplikanci { get; init; }
    public DbSet<Asesor> Asesorzy { get; init; }
    public DbSet<BiuroNagrody> BiuraNagrody { get; init; }
    public DbSet<CzłonekJury> CzłonkowieJury { get; init; }
    public DbSet<EdycjaKonkursu> EdycjeKonkursu { get; init; }
    public DbSet<EkspertIpma> EksperciIpma { get; init; }
    public DbSet<Harmonogram> Harmonogramy { get; init; }
    public DbSet<Kategoria> Kategorie { get; init; }
    public DbSet<OcenaIndywidualna> OcenyIndywidualne { get; init; }
    public DbSet<OcenaKońcowa> OcenyKońcowe { get; init; }
    public DbSet<OcenaWstępna> OcenyWstępne { get; init; }
    public DbSet<OpłataZgłoszeniowa> OpłatyZgłoszeniowe { get; init; }
    public DbSet<Projekt> Projekty { get; init; }
    public DbSet<RaportAplikacyjny> RaportyAplikacyjne { get; init; }
    public DbSet<RaportZWizyty> RaportyZWizyty { get; init; }
    public DbSet<UmowaWspółpracy> UmowyWspółpracy { get; init; }
    public DbSet<WniosekAplikacyjny> WnioskiAplikacyjne { get; init; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.ApplyConfigurationsFromAssembly(typeof(BaseEntityConfiguration<>).Assembly);
    }
    
    private void UpdateTimestamps(object? sender, EntityEntryEventArgs e)
    {
        if (e.Entry.Entity is not ITimeTrackable timeTrackable)
        {
            return;
        }

        switch (e.Entry.State)
        {
            case EntityState.Added:
                timeTrackable.CreatedAt = _timeProvider.GetUtcNow();
                timeTrackable.UpdatedAt = _timeProvider.GetUtcNow();
                return;
            case EntityState.Modified:
                timeTrackable.UpdatedAt = _timeProvider.GetUtcNow();
                return;
        }
    }
}