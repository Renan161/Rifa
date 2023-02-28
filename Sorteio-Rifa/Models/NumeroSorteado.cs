using static Sorteio_Rifa.Models.Concorrente;

namespace Sorteio_Rifa.Models
{
    public class NumeroSorteado
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public bool Status { get; set; }

        // Relacionamentos
        public Sorteio Sorteio { get; set; }        
        
        public Concorrente Concorrente { get; set; }

    }
}