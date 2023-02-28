using Microsoft.EntityFrameworkCore;
using Sorteio_Rifa.Models;
t;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Concorrente> Concorrentes { get; set; }
    public DbSet<NumeroSorteado> NumerosSorteados { get; set; }
    public DbSet<Organizador> Organizadores { get; set; }
    public DbSet<Sorteio> Sorteios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Concorrente_Sorteio>().HasKey(am => new
        {
            am.ConcorrenteId,
            am.SorteioId
        });

        modelBuilder.Entity<Concorrente_Sorteio>().HasOne(m => m.Concorrente).WithMany(am => am.Concorrentes_Sorteios).HasForeignKey(m => m.ConcorrenteId);
        modelBuilder.Entity<Concorrente_Sorteio>().HasOne(m => m.Sorteio).WithMany(am => am.Concorrentes_Sorteios).HasForeignKey(m => m.SorteioId);

        // Relacionamento de um concorrente para vários números
        modelBuilder.Entity<Concorrente>()
            .HasMany(c => c.NumerosSorteados)
            .WithOne(n => n.Concorrente)
            .HasForeignKey(n => n.Concorrente.Id);
        // Relacionamento de um sorteio para vários números
        modelBuilder.Entity<Sorteio>()
            .HasMany(nu=> nu.NumerosSorteados)
            .WithOne(so => so.Sorteio)
            .HasForeignKey(so => so.Sorteio.Id);

        // Relacionamento de um sorteio para um organizador
        modelBuilder.Entity<Sorteio>()
            .HasOne(s => s.Organizador)
            .WithMany(o => o.Sorteios);
    }
}