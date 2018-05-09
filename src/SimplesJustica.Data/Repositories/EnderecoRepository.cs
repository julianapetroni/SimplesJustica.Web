using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class EnderecoRepository : Repository<Empresa>, IEmpresaRepository
    {
        internal EnderecoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
