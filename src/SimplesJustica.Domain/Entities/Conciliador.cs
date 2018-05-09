using System.Collections.Generic;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Entities
{
    public class Conciliador : Usuario
    {
        public Conciliador()
        {
            Enderecos = new List<Endereco>();
            Reclamacoes = new List<Reclamacao>();
        }

        public string Nome { get; set; }

        #region Relacionamentos

        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Reclamacao> Reclamacoes { get; set; }

        #endregion
    }
}
