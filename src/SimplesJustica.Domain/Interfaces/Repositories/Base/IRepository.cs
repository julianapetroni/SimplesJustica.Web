using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> Listar();
        Task<List<TEntity>> Listar(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Obter(Guid id);

        IEnumerable<TEntity> Adicionar(List<TEntity> entities);
        TEntity Adicionar(TEntity entity);
        void Atualizar(ICollection<TEntity> entities);
        void Atualizar(TEntity entity);
        IEnumerable<TEntity> Deletar(ICollection<TEntity> entites);
        TEntity Deletar(TEntity entity);
    }
}
