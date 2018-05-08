using System;

namespace SimplesJustica.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}
