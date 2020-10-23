﻿using System;
using KnivesStore.DAL.DataAccessors.DB.Repositories;
using KnivesStore.DAL.Models;

namespace KnivesStore.DAL.DataAccessors.DB.UnitOfWork
{
    public class KnivesDbUnitOfWork : IUnitOfWork
    {
        private readonly KnivesStoreContext _context;
        private bool _isDisposed;

        public IRepository<Knife> KnifeRepository { get; private set; }
        public IRepository<Sale> SaleRepository { get; private set; }
        public IRepository<Producer> ProducerRepository { get; private set; }
        public IRepository<KnifeCategory> KnifeCategoryRepository { get; private set; }


        public KnivesDbUnitOfWork(string connectionString)
        {
            _context = new KnivesStoreContext(connectionString);
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            ProducerRepository = new Repository<Producer>(_context);
            KnifeRepository = new Repository<Knife>(_context);
            SaleRepository = new Repository<Sale>(_context);
            KnifeCategoryRepository = new Repository<KnifeCategory>(_context);
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
                    _context.Dispose();
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