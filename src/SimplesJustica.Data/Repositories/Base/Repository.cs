using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SimplesJustica.Data.Context;
using SimplesJustica.Domain.Entities.Base;
using SimplesJustica.Domain.Interfaces.Repositories.Base;

namespace SimplesJustica.Data.Repositories.Base
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly SimplesJusticaContext _context;
        private readonly DbSet<TEntity> Db;

        internal Repository(SimplesJusticaContext context)
        {
            _context = context;
            Db = _context.Set<TEntity>();
        }

        public Task<TEntity> Get(Guid id)
        {
            return Db.FindAsync(id);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Where(predicate);
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.SingleOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> List()
        {
            return Db.ToListAsync();
        }

        public Task<List<TEntity>> List(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Where(predicate).ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            entity.DataCadastro = DateTime.Now;
            entity.Id = Guid.NewGuid();
            return Db.Add(entity);
        }

        public IEnumerable<TEntity> Add(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DataCadastro = DateTime.Now;
            }
            return Db.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            Db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        public TEntity Delete(TEntity entity)
        {
            return Db.Remove(entity);
        }

        public IEnumerable<TEntity> Delete(ICollection<TEntity> entites)
        {
            return Db.RemoveRange(entites);
        }
    }
}
