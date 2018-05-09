using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        internal EmpresaRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
