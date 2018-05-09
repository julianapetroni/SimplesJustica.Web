using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    public class ReclamacaoRepository : Repository<Reclamacao>, IReclamacaoRepository
    {
        public ReclamacaoRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }
    }
}
