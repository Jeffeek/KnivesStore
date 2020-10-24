using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class KnifeRepository : RepositoryBase<Knife>
    {
        public KnifeRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Knife> GetAll()
        {
            return Context.Set<Knife>()
                                        .Include(x => x.Producer)
                                        .Include(x => x.Producer)
                                        .AsQueryable();
        }

        public override void Update(Knife item)
        {
            var knives = GetAll();
            var map = knives.Single(x => x.Id == item.Id);
            map.Name = item.Name;
            map.CategoryId = item.CategoryId;
            map.Price = map.Price;
            map.ProducerId = item.ProducerId;
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
