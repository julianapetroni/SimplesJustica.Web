using System;
using System.Collections.Generic;
using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;
using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Entities
{
    public class Autor : Usuario
    {
        public Autor()
        {
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public CPF CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public Genero Genero { get; set; }
        public List<Endereco> Enderecos { get; set; }
    }
}
