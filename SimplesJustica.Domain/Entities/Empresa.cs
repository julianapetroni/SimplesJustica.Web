using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Entities
{
    public class Empresa : Reu
    {
        public string NomeFantasia { get; set; }
        public CNPJ CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public LinhaDeNegocio LinhaDeNegocio { get; set; }
    }
}
