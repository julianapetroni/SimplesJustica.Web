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
            Reclamacoes = new List<Reclamacao>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public CPF CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public Genero Genero { get; set; }

        #region Relacionamentos

        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Reclamacao> Reclamacoes { get; set; }
        
        #endregion

    }
}
