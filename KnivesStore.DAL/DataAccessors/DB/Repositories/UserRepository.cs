using System.Collections.Generic;
using System.Linq;
using KnivesStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnivesStore.DAL.DataAccessors.DB.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(DbContext context) : base(context)
        {

        }

        public override IEnumerable<User> GetAll()
        {
            return Context.Set<User>().AsQueryable();
        }

        public override void Update(User item)
        {
            var users = GetAll();
            var map = users.Single(x => x.Id == item.Id);
            Context.Entry(map).State = EntityState.Modified;
        }
    }
}
