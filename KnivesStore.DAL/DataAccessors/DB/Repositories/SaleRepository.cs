using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>
    {
        public SaleRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Sale> GetAll()
        {
            return Context.Set<Sale>().Include(x => x.Knife).AsQueryable();
        }

        public override void Update(Sale item)
        {
            var sales = GetAll();
            var map = sales.Single(x => x.Id == item.Id);
            map.Date = item.Date;
            map.Sum = item.Sum;
            map.KnifeId = item.KnifeId;
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
