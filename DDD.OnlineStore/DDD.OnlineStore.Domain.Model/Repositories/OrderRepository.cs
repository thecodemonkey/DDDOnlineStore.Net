using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class OrderRepository : RepositoryBase<Order>
    {
        public OrderRepository(IRepository<Order> repository)
            : base(repository)  {  }

        public IEnumerable<Order> GetOrdersByUserID(int userID) 
        {
            return this.Queryable.Where(o => o.User.ID == userID).ToArray();
        }
    }
}
