using Microsoft.EntityFrameworkCore;

namespace Ipma.Infrastructure;

public class IpmaDbContext : DbContext
{
    public IpmaDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}