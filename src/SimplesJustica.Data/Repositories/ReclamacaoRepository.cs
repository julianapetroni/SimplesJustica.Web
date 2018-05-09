using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class ReclamacaoRepository : Repository<Reclamacao>, IReclamacaoRepository
    {
        internal ReclamacaoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
