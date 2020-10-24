using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity: class, IEquatable<TEntity>
    {
        private bool _isDisposed;
        protected DbContext Context;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
            //Context.Set<TEntity>().Load();
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
                    Context.Dispose();
                }

                _isDisposed = true;
            }
        }

        public abstract IEnumerable<TEntity> GetAll();

        public TEntity Get(Func<TEntity, bool> predicate)
        {
            return GetAll().SingleOrDefault(predicate);
        }

        public void Insert(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        public abstract void Update(TEntity item);

        public void Delete(TEntity item)
        {
            Context.Set<TEntity>().Remove(GetItem(item));
        }

        protected TEntity GetItem(TEntity item)
        {
            var table = Context.Set<TEntity>();
            var itemIn = table.Single(x => x.Equals(item));
            return itemIn;
        }
    }
}
