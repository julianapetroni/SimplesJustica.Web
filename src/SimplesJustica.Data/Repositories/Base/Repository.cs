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

        public Task<TEntity> Obter(Guid id)
        {
            return Db.FindAsync(id);
        }

        public IQueryable<TEntity> Encontrar(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Where(predicate);
        }

        public Task<TEntity> Obter(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.SingleOrDefaultAsync(predicate);
        }

        public Task<List<TEntity>> Listar()
        {
            return Db.ToListAsync();
        }

        public Task<List<TEntity>> Listar(Expression<Func<TEntity, bool>> predicate)
        {
            return Db.Where(predicate).ToListAsync();
        }

        public TEntity Adicionar(TEntity entity)
        {
            entity.DataCadastro = DateTime.Now;
            return Db.Add(entity);
        }

        public IEnumerable<TEntity> Adicionar(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.DataCadastro = DateTime.Now;
            }
            return Db.AddRange(entities);
        }

        public void Atualizar(TEntity entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            Db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Atualizar(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Atualizar(entity);
            }
        }

        public TEntity Deletar(TEntity entity)
        {
            return Db.Remove(entity);
        }

        public IEnumerable<TEntity> Deletar(ICollection<TEntity> entites)
        {
            return Db.RemoveRange(entites);
        }
    }
}
