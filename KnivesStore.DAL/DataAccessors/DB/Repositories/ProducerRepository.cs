using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class ProducerRepository : RepositoryBase<Producer>
    {
        public ProducerRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Producer> GetAll()
        {
            return Context.Set<Producer>()
                .Include(x => x.Knives)
                .ToList();
        }

        public override void Update(Producer item)
        {
            var producers = GetAll();
            var map = producers.Single(x => x.Id == item.Id);
            map.Name = item.Name;
            map.Country = item.Country;
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
