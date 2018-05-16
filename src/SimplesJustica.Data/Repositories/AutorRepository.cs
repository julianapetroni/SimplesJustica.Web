using System;
using SimplesJustica.Data.Context;
using SimplesJustica.Data.Repositories.Base;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories;

namespace SimplesJustica.Data.Repositories
{
    internal class AutorRepository : Repository<Autor>, IAutorRepository
    {
        internal AutorRepository(SimplesJusticaContext context) 
            : base(context)
        {
        }

        public Autor Add(Autor autor, Guid id)
        {
            autor.Id = id;
            autor.DataCadastro = DateTime.Now;
            return _context.Autores.Add(autor);
        }
    }
}
