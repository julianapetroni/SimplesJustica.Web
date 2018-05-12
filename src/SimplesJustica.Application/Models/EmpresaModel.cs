using System;
using System.Collections.Generic;
using System.Text;

namespace SimplesJustica.Application.Models
{
    public class EmpresaModel
    {
        protected EmpresaModel()
        {
            Enderecos = new List<EnderecoModel>();
            Reclamacoes = new List<ReclamacaoModel>();
        }

        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int LinhaDeNegocio { get; set; }

        public virtual List<EnderecoModel> Enderecos { get; set; }
        public virtual List<ReclamacaoModel> Reclamacoes { get; set; }

    }
}
