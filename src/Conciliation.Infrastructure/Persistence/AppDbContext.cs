using Conciliation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conciliation.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    //  AQUI ficam as tabelas
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<ProviderTransaction> ProviderTransactions => Set<ProviderTransaction>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Config Payment
        modelBuilder.Entity<Payment>().HasKey(x => x.Id);
        modelBuilder.Entity<Payment>().HasIndex(x => x.CorrelationId).IsUnique();

        modelBuilder.Entity<Payment>()
            .Property(x => x.Amount)
            .HasPrecision(18, 2);

        // Config ProviderTransaction
        modelBuilder.Entity<ProviderTransaction>().HasKey(x => x.Id);

        modelBuilder.Entity<ProviderTransaction>()
            .Property(x => x.Amount)
            .HasPrecision(18, 2);
    }
}
