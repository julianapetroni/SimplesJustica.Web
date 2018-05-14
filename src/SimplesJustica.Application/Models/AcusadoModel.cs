using System;

namespace SimplesJustica.Application.Models
{
    public class AcusadoModel : ReuModel
    {
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Genero { get; set; }
    }
}
