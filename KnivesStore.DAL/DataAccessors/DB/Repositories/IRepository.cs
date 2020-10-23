using System;
using System.Collections.Generic;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Func<T, bool> predicate);
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}