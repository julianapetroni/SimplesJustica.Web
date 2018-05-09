using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    public class AcusadoRepository : Repository<Acusado>, IAcusadoRepository
    {
        public AcusadoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
