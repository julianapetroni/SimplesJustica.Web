using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class AcusadoRepository : Repository<Acusado>, IAcusadoRepository
    {
        internal AcusadoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
