using System.Threading.Tasks;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAcusadoRepository Acusados { get; set; }
        IAutorRepository Autores { get; set; }
        IConciliadorRepository Conciliadores { get; set; }
        IEmpresaRepository Empresas { get; set; }
        IReclamacaoRepository Reclamacoes { get; set; }

        bool Commit { get; set; }
        Task<bool> CommitAsync { get; set; }
    }
}
