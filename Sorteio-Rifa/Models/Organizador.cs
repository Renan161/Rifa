namespace Sorteio_Rifa.Models
{
    public class Organizador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string NumeroCelularOrganizador { get; set; }
        public string Cpf { get; set; }

        // Relação com a classe sorteio
        public ICollection<Sorteio> Sorteios { get; set; }


    }
}
