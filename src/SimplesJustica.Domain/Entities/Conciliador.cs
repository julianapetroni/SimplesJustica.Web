using System.Collections.Generic;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Entities
{
    public class Conciliador : Usuario
    {
        public Conciliador()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
