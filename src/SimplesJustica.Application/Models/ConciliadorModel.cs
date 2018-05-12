using System;
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

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public virtual List<EnderecoModel> Enderecos { get; set; }
        public virtual List<ReclamacaoModel> Reclamacoes { get; set; }
    }
}
