using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class KnifeCategoryRepository : RepositoryBase<KnifeCategory>
    {
        public KnifeCategoryRepository(DbContext context) : base(context)
        {
        }

        public override IEnumerable<KnifeCategory> GetAll()
        {
            return Context.Set<KnifeCategory>().AsQueryable();
        }

        public override void Update(KnifeCategory item)
        {
            var categories = GetAll();
            var map = categories.Single(x => x.Id == item.Id);
            map.Category = item.Category;
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
