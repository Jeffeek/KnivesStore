using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class CheckRepository : RepositoryBase<Check>
    {
        public CheckRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<Check> GetAll()
        {
            return Context.Set<Check>()
                .Include(x => x.User)
                .ToList();
        }

        public override void Update(Check item)
        {
            var sales = GetAll();
            var map = sales.Single(x => x.Id == item.Id);
            map.Date = item.Date;
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
