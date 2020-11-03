using System;
using KnivesStore.DAL.DataAccessors.DB.Repositories;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.UnitOfWork
{
    public class KnivesDbUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _isDisposed;

        public IRepository<User> UserRepository { get; private set; }
        public IRepository<Knife> KnifeRepository { get; private set; }
        public IRepository<Sale> SaleRepository { get; private set; }
        public IRepository<Producer> ProducerRepository { get; private set; }
        public IRepository<KnifeCategory> KnifeCategoryRepository { get; private set; }

        public KnivesDbUnitOfWork(DbContext context)
        {
            _context = context;
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            ProducerRepository = new ProducerRepository(_context);
            KnifeRepository = new KnifeRepository(_context);
            SaleRepository = new SaleRepository(_context);
            KnifeCategoryRepository = new KnifeCategoryRepository(_context);
            UserRepository = new UserRepository(_context);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
                if (disposing)
                {
                    ProducerRepository.Dispose();
                    KnifeRepository.Dispose();
                    SaleRepository.Dispose();
                    KnifeCategoryRepository.Dispose();
                }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}