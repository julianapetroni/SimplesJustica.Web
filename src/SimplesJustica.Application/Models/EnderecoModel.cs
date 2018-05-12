using System;

namespace SimplesJustica.Application.Models
{
    public class EnderecoModel
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public bool Principal { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
