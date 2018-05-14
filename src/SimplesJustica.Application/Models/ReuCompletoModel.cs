using System;
using System.Collections.Generic;

namespace SimplesJustica.Application.Models
{
    public class ReuCompletoModel
    {
        public ReuCompletoModel()
        {
            Enderecos = new List<EnderecoModel>();
            Reclamacoes = new List<ReclamacaoModel>();
        }

        // Entity
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        // Usuário
        public string Email { get; set; }
        public string Nome { get; set; }

        // Acusado
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Genero { get; set; }

        // Empresa
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int LinhaDeNegocio { get; set; }

        public virtual List<EnderecoModel> Enderecos { get; set; }
        public virtual List<ReclamacaoModel> Reclamacoes { get; set; }

        public ReuType Type { get; set; }   
    }
}
