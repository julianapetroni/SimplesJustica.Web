using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class ConciliadorRepository : Repository<Conciliador>, IConciliadorRepository
    {
        internal ConciliadorRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
