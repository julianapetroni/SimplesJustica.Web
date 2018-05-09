using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    public class EnderecoRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EnderecoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
