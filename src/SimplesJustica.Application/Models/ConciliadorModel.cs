using System.Collections.Generic;

namespace SimplesJustica.Application.Models
{
    public class ConciliadorModel
    {
        public ConciliadorModel()
        {
            Enderecos = new List<EnderecoModel>();
            Reclamacoes = new List<ReclamacaoModel>();
        }

        public string Nome { get; set; }

        public virtual List<EnderecoModel> Enderecos { get; set; }
        public virtual List<ReclamacaoModel> Reclamacoes { get; set; }
    }
}
