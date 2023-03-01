using Microsoft.EntityFrameworkCore;
using Sorteio_Rifa.Models;
using Sorteio_RifaMVC.Data;

namespace Sorteio_RifaMVC
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            // Look for any existing data.
            if (context.Concorrentes.Any() || context.Concorrentes_Sorteios.Any() ||
                context.NumerosSorteados.Any() || context.Organizadores.Any() || context.Sorteios.Any())
            {
                return;   // DB has been seeded
            }

            var rand = new Random();

            // Seed Concorrentes
            var concorrentes = new List<Concorrente>
            {
                new Concorrente { Nome = "John Doe", Email = "john.doe@example.com", NumeroCelular = "123456789" },
                new Concorrente { Nome = "Jane Doe", Email = "jane.doe@example.com", NumeroCelular = "987654321" },
                new Concorrente { Nome = "Bob Smith", Email = "bob.smith@example.com", NumeroCelular = "55555555" }
            };
            context.Concorrentes.AddRange(concorrentes);
            context.SaveChanges();

            // Seed Organizadores
            var organizadores = new List<Organizador>
            {
                new Organizador { Nome = "Alice Smith", Email = "alice.smith@example.com", NumeroCelularOrganizador = "999999999", Cpf = "12345678901" },
                new Organizador { Nome = "Bob Johnson", Email = "bob.johnson@example.com", NumeroCelularOrganizador = "88888888", Cpf = "23456789012" },
                new Organizador { Nome = "Carol Williams", Email = "carol.williams@example.com", NumeroCelularOrganizador = "77777777", Cpf = "34567890123" }
            };
            context.Organizadores.AddRange(organizadores);
            context.SaveChanges();

            // Seed Sorteios
            var sorteios = new List<Sorteio>
            {
                new Sorteio { Nome = "Sorteio de Aniversário", Descricao = "Sorteio de aniversário do clube", DataSorteio = new DateTime(2022, 10, 15), Premio = "Um carro novo", Organizador = organizadores[0] },
                new Sorteio { Nome = "Sorteio de Natal", Descricao = "Sorteio especial de Natal", DataSorteio = new DateTime(2022, 12, 25), Premio = "Uma viagem para o Caribe", Organizador = organizadores[1] },
                new Sorteio { Nome = "Sorteio de Carnaval", Descricao = "Sorteio de carnaval", DataSorteio = new DateTime(2023, 3, 5), Premio = "Um celular novo", Organizador = organizadores[2] }
            };
            context.Sorteios.AddRange(sorteios);
            context.SaveChanges();

            // Seed Concorrentes_Sorteios
            var concorrentes_sorteios = new List<Concorrente_Sorteio>
            {
                new Concorrente_Sorteio { Concorrente = concorrentes[0], Sorteio = sorteios[0] },
                new Concorrente_Sorteio { Concorrente =  concorrentes[1], Sorteio = sorteios[0] }
            };
            var NumeroSorteado = new List<NumeroSorteado> {
            new NumeroSorteado
            {
                Id = 1,
                Numero = 1234,
                Status = false,
                ConcorrenteId = 1,
                SorteioId = 1
            },
            new NumeroSorteado
            {
                Id = 2,
                Numero = 5678,
                Status = false,
                ConcorrenteId = 2,
                SorteioId = 1
            },
            new NumeroSorteado
            {
                Id = 3,
                Numero = 9101,
                Status = false,
                ConcorrenteId = 3,
                SorteioId = 1
            }
            };
            }
    }
}