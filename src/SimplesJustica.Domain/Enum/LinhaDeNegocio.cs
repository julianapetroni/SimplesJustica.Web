using System.ComponentModel.DataAnnotations;

namespace SimplesJustica.Domain.Enum
{
    public enum LinhaDeNegocio
    {
        [Display(Name = "Varejo")]
        Varejo,

        [Display(Name = "Saúde")]
        Saude,

        [Display(Name = "Transporte")]
        Transporte,

        [Display(Name = "Educação")]
        Educacao,

        [Display(Name = "Bens de consumo")]
        BensDeConsumo,

        [Display(Name = "Prestadora de Serviços")]
        PrestadoraDeServicos,

        [Display(Name = "Tecnologia")]
        Tecnologia
    }
}
