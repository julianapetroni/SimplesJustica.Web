using System;
using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Entities
{
    public class Acusado : Reu
    {
        public string Sobrenome { get; set; }
        public CPF CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public Genero Genero { get; set; }
    }
}
