using System;
using System.Threading.Tasks;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories;
using SimplesJustica.Domain.Interfaces.Repositories;
using SimplesJustica.Domain.Interfaces.UnitOfWork;

namespace SimplesJustica.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimplesJusticaContext _context;

        public IAcusadoRepository Acusados { get; set; }
        public IAutorRepository Autores { get; set; }
        public IConciliadorRepository Conciliadores { get; set; }
        public IEmpresaRepository Empresas { get; set; }
        public IReclamacaoRepository Reclamacoes { get; set; }
      
        public UnitOfWork(SimplesJusticaContext context)
        {
            _context = context;
            Acusados = new AcusadoRepository(_context);
            Autores = new AutorRepository(_context);
            Conciliadores = new ConciliadorRepository(_context);
            Empresas = new EmpresaRepository(_context);
            Reclamacoes = new ReclamacaoRepository(_context);
        }

        public bool Commit()
        {
            var result = _context.SaveChanges();
            return result > 0;
        }

        public async Task<bool> CommitAsync()
        {
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
