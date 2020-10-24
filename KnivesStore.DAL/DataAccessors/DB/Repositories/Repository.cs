using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class, IEquatable<TEntity>
    {
        private bool _isDisposed;
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            _context.Set<TEntity>().Load();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().ToList().SingleOrDefault(predicate);
        }

        public void Insert(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        //TODO: доделать, не обновляет
        public void Update(TEntity item)
        {
            var dbItem = GetItem(item);
            dbItem = item;
            _context.Entry(GetItem(dbItem)).State = EntityState.Modified;
        }

        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(GetItem(item));
        }

        private TEntity GetItem(TEntity item)
        {
            var table = _context.Set<TEntity>();
            var itemIn = table.Single(x => x.Equals(item));
            return itemIn;
        }
    }
}
