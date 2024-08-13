// MotoRentalContext.cs
using Microsoft.EntityFrameworkCore;

public class MotoRentalContext : DbContext
{
    public DbSet<Moto> Motos { get; set; }
    public DbSet<Entregador> Entregadores { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }

    public MotoRentalContext(DbContextOptions<MotoRentalContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Moto>().HasIndex(m => m.Placa).IsUnique();
        modelBuilder.Entity<Entregador>().HasIndex(e => e.Cnpj).IsUnique();
        modelBuilder.Entity<Entregador>().HasIndex(e => e.NumeroCNH).IsUnique();
        // Additional configuration is needed
    }
}
