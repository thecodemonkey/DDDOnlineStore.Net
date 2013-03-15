using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository(IRepository<User> repository) : base(repository) { }

        public IQueryable<User> SelectUserByName(string name)
        {
            return this.Queryable.Where(x => x.LoginName.ToLower().Equals(name.ToLower()));
        }

        public User GetUserByName(string name)
        {
            return this.SelectUserByName(name)
                       //.Include(t => t.Cart)
                       .FirstOrDefault();
        }
    }
}
