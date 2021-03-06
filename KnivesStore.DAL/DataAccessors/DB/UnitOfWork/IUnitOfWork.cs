﻿using System;
using KnivesStore.DAL.DataAccessors.DB.Repositories;
using KnivesStore.DAL.Models;

namespace KnivesStore.DAL.DataAccessors.DB.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Knife> KnifeRepository { get; }
        IRepository<Check> CheckRepository { get; }
        IRepository<Sell> SellRepository { get; }
        IRepository<Producer> ProducerRepository { get; }
        IRepository<KnifeCategory> KnifeCategoryRepository { get; }
        IRepository<User> UserRepository { get; }
        void Save();
    }
}
