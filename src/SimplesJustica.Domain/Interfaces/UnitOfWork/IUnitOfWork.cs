using System;
using System.Threading.Tasks;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAcusadoRepository Acusados { get; }
        IAutorRepository Autores { get; }
        IConciliadorRepository Conciliadores { get; }
        IEmpresaRepository Empresas { get; }
        IReclamacaoRepository Reclamacoes { get; }

        bool Commit();
        Task<bool> CommitAsync();
    }
}
