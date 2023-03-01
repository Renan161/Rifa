namespace Sorteio_Rifa.Models
{
    public class Sorteio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataSorteio { get; set; }
        public string Premio { get; set; }

        // Relacionamentos
       
        public Organizador Organizador { get; set; }
        public ICollection<NumeroSorteado> NumerosSorteados { get; set; }

        public List<Concorrente_Sorteio> Concorrentes_Sorteios { get; set; }

    }
}
