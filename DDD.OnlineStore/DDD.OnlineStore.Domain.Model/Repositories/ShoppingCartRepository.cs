using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>
    {
        public ShoppingCartRepository(IRepository<ShoppingCart> repository) : base(repository) { }

        public ShoppingCart GetByUserID(int userID)
        {
            return this.Queryable.Where(s => s.UserID == userID).FirstOrDefault();
        }
    }
}
