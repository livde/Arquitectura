using Microsoft.EntityFrameworkCore;
using library.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace library.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly LibraryContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(LibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<TEntity>();
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public virtual List<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
