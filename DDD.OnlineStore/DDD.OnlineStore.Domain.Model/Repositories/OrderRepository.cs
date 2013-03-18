using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class OrderRepository : RepositoryBase<PurchaseOrder>
    {
        public OrderRepository(IRepository<PurchaseOrder> repository)
            : base(repository)  {  }

        public IEnumerable<PurchaseOrder> GetOrdersByUserID(int userID) 
        {
            throw new NotImplementedException();
            //return this.Queryable.Where(o => o.Users.ID == userID).ToArray();
        }
    }
}
