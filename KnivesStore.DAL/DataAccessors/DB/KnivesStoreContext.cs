using System;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB
{
    public class KnivesStoreContext : DbContext
    {
        public KnivesStoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Knife> Knives { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<KnifeCategory> KnivesCategories { get; set; }
    }
}