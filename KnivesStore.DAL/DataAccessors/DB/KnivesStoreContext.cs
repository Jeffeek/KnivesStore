using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB
{
    public class KnivesStoreContext : DbContext
    {
        private string _connectionString;
        public KnivesStoreContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var ctr = ConfigurationManager.ConnectionStrings["KnivesDB"].ConnectionString;
            optionsBuilder.UseMySql(_connectionString);
        }

        public DbSet<Knife> Knives { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<KnifeCategory> KnifeCategories { get; set; }
    }
}