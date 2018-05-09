using System;
using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;

namespace SimplesJustica.Domain.Entities
{
    public class Reclamacao : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusReclamacao Status { get; set; }

        #region Relacionamento

        public Guid AutorId { get; set; }
        public virtual Autor Audor { get; set; }

        public Guid ReuId { get; set; }
        public virtual Reu Reu { get; set; }

        public Guid ConciliadorId { get; set; }
        public virtual Conciliador Conciliador { get; set; }
        
        #endregion

    }
}
