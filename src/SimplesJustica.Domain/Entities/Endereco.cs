using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string CPF { get; set; }
        public Usuario Usuario { get; set; }
        public bool Principal { get; set; }
    }
}
