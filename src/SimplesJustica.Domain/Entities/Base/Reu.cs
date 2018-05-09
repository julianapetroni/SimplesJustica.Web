using System.Collections.Generic;

namespace SimplesJustica.Domain.Entities.Base
{
    public abstract class Reu : Usuario
    {
        protected Reu()
        {
            Enderecos = new List<Endereco>();
            Reclamacoes = new List<Reclamacao>();
        }

        public string Nome { get; set; }

        #region Relacionamento

        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Reclamacao> Reclamacoes { get; set; }

        #endregion
    }
}
