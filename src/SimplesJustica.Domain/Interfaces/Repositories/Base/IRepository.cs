using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimplesJustica.Domain.Entities.Base;

namespace SimplesJustica.Domain.Interfaces.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> List();
        Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(Guid id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Add(List<TEntity> entities);
        TEntity Add(TEntity entity);
        void Update(ICollection<TEntity> entities);
        void Update(TEntity entity);
        IEnumerable<TEntity> Delete(ICollection<TEntity> entites);
        TEntity Delete(TEntity entity);
    }
}
