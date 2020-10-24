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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    var producers = new Producer[]
        //    {
        //        new Producer(){Country = "Belarus", Id = 1, Name = "Jopa"}, 
        //        new Producer() {Country = "Russia", Id = 2, Name = "Piska"}
        //    };
        //    modelBuilder.Entity<Producer>().HasData(producers);
        //    var categories = new KnifeCategory[]
        //    {
        //        new KnifeCategory() {Category = "Butcher", Id = 1}, 
        //        new KnifeCategory() {Category = "Flip", Id = 2}, 
        //        new KnifeCategory() {Category = "Simple", Id = 3}
        //    };
        //    modelBuilder.Entity<KnifeCategory>().HasData(categories);
        //    var knives = new Knife[]
        //    {
        //        new Knife(){Id = 1, Name = "Piska223", CategoryId = 1, Price = 3600, ProducerId = 1},
        //        new Knife(){Id = 2, Name = "JOPAAAAA", CategoryId = 2, Price = 8900, ProducerId = 2},
        //        new Knife(){Id = 3, Name = "Pizdec13", CategoryId = 3, Price = 13000, ProducerId = 1}
        //    };
        //    modelBuilder.Entity<Knife>().HasData(knives);
        //    var sales = new Sale[]
        //    {
        //        new Sale() {Date = DateTime.Now, Id = 1, KnifeId = 1,  Sum = 3600}, 
        //        new Sale() {Date = DateTime.Now, Id = 2, KnifeId = 2,  Sum = 8900}, 
        //        new Sale() {Date = DateTime.Now, Id = 3, KnifeId = 3,  Sum = 13000}, 
        //        new Sale() {Date = DateTime.Now, Id = 4, KnifeId = 1,  Sum = 3600}
        //    };
        //    modelBuilder.Entity<Sale>().HasData(sales);
        //    Producers.AddRange(producers);
        //    KnivesCategories.AddRange(categories);
        //    Knives.AddRange(knives);
        //    Sales.AddRange(sales);
        //}

        public DbSet<Knife> Knives { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<KnifeCategory> KnivesCategories { get; set; }
    }
}