using System;
using SimplesJustica.Domain.Entities;
using SimplesJustica.Domain.Interfaces.Repositories.Base;

namespace SimplesJustica.Domain.Interfaces.Repositories
{
    public interface IAutorRepository : IRepository<Autor>
    {
        Autor Add(Autor autor, Guid id);
    }
}
