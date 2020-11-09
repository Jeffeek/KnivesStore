using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class SellRepository : RepositoryBase<Sell>
    {
        public SellRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Sell> GetAll()
        {
            return Context.Set<Sell>()
                .Include(x => x.Check)
                .Include(x => x.Knife)
                .ToList();
        }

        public override void Update(Sell item)
        {
            var sales = GetAll();
            var map = sales.Single(x => x.Id == item.Id);
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
