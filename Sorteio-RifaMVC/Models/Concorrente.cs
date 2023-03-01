namespace Sorteio_Rifa.Models
{
   
    public class Concorrente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NumeroCelular { get; set; }
        public int SorteioId { get; set; }
        public int ConcorrenteId { get; set; }

        // Relacionamentos

        public List<Concorrente_Sorteio> Concorrentes_Sorteios { get; set; }

        
        public ICollection<NumeroSorteado> NumerosSorteados { get; set; }

        
    }
    
}

