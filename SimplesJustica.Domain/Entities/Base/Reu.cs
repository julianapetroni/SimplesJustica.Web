using System.Collections.Generic;

namespace SimplesJustica.Domain.Entities.Base
{
    public class Reu : Usuario
    {
        public Reu()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
