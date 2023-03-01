using Microsoft.EntityFrameworkCore;
using Sorteio_Rifa.Models;

namespace Sorteio_RifaMVC.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Concorrente> Concorrentes { get; set; }
        public DbSet<Concorrente_Sorteio> Concorrentes_Sorteios { get; set; }
        public DbSet<NumeroSorteado> NumerosSorteados { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Sorteio> Sorteios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DefaultConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concorrente_Sorteio>()
                .HasKey(cs => new { cs.ConcorrenteId, cs.SorteioId });

            modelBuilder.Entity<Concorrente_Sorteio>()
                .HasOne(cs => cs.Concorrente)
                .WithMany(c => c.Concorrentes_Sorteios)
                .HasForeignKey(cs => cs.ConcorrenteId);

            modelBuilder.Entity<Concorrente_Sorteio>()
                .HasOne(cs => cs.Sorteio)
                .WithMany(s => s.Concorrentes_Sorteios)
                .HasForeignKey(cs => cs.SorteioId);
        }
    }
}