using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> Obter(Guid id);
        Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        Task<ICollection<TEntity>> Listar();
        Task<ICollection<TEntity>> Listar(Expression<Func<TEntity, bool>> predicate);

        Task Adicionar(TEntity obj);
        Task Adicionar(ICollection<TEntity> objs);
        Task<bool> Atualizar(Guid id, TEntity obj);
        Task<bool> Atualizar(Expression<Func<TEntity, bool>> predicate, TEntity obj);
        Task<bool> Deletar(Guid id);
        Task<bool> Deletar(Expression<Func<TEntity, bool>> predicate);
    }
}
