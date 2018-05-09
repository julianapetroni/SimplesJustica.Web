using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    public class ConciliadorRepository : Repository<Conciliador>, IConciliadorRepository
    {
        public ConciliadorRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
