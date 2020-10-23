using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private bool _isDisposed;
        private KnivesStoreContext _context;

        public Repository(KnivesStoreContext context)
        {
            _context = context;
            _context.Set<TEntity>().Load();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _isDisposed = true;
        }

        protected void Dispose(bool isDisposing)
        {
            if (!_isDisposed)
            {
                if (isDisposing)
                {
                    //_context.Dispose();
                }
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Include(x => x).ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().ToList().SingleOrDefault(predicate);
        }

        public void Insert(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }
    }
}
