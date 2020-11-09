using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB
{
    public sealed class KnivesStoreContext : DbContext
    {
        public KnivesStoreContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Knife> Knives { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<KnifeCategory> KnivesCategories { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Sell> Sells { get; set; }
    }
}