namespace Sorteio_Rifa.Models
{
    public class Concorrente_Sorteio
    {
        public int ConcorrenteId { get; set; }
        public Concorrente Concorrente { get; set; }

        public int SorteioId {get; set;} 
        public Sorteio Sorteio { get; set; }

       
    }
}
