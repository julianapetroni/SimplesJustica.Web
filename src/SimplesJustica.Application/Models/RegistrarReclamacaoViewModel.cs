using System;
using System.Collections.Generic;

namespace SimplesJustica.Application.Models
{
    public class RegistrarReclamacaoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public Guid ReuId { get; set; }
        public List<IdentificacaoBasicaModel> Reus { get; set; }
    }
}
