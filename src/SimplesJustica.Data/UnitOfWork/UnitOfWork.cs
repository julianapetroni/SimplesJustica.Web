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

        private IAcusadoRepository _acusados;
        public IAcusadoRepository Acusados
        {
            get
            {
                if(_acusados == null)
                    _acusados = new AcusadoRepository(_context);

                return _acusados;
            }
        }

        private IAutorRepository _autores;
        public IAutorRepository Autores
        {
            get
            {
                if(_autores == null)
                    _autores = new AutorRepository(_context);

                return _autores;
            }
        }

        private IConciliadorRepository _conciliadores;
        public IConciliadorRepository Conciliadores
        {
            get
            {
                if(_conciliadores == null)
                    _conciliadores = new ConciliadorRepository(_context);

                return _conciliadores;
            }
        }

        private IEmpresaRepository _empresas;
        public IEmpresaRepository Empresas
        {
            get
            {
                if(_empresas == null)
                    _empresas = new EmpresaRepository(_context);

                return _empresas;
            }
        }

        private IReclamacaoRepository _reclamacoes;
        public IReclamacaoRepository Reclamacoes
        {
            get
            {
                if(_reclamacoes == null)
                    _reclamacoes = new ReclamacaoRepository(_context);

                return _reclamacoes;
            }
        }

        public UnitOfWork(SimplesJusticaContext context)
        {
            _context = context;
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
