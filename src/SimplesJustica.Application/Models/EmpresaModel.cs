namespace SimplesJustica.Application.Models
{
    public class EmpresaModel : ReuModel
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int LinhaDeNegocio { get; set; }
    }
}
