using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Enum;

namespace SimplesJustica.Domain.Entities
{
    public class Reclamacao : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusReclamacao Status { get; set; }

        public Autor Audor { get; set; }
        public Reu Reu { get; set; }
    }
}
