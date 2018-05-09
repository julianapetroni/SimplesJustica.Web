using SimplesJustica.Domain.ValueObjects;

namespace SimplesJustica.Domain.Entities.Base
{
    public abstract class Usuario : Entity
    {
        public Email Email { get; set; }
    }
}
