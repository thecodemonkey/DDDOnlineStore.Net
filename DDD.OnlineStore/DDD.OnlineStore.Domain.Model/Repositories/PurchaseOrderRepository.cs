using DDD.OnlineStore.Domain.Common;
using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Repositories
{
    public class PurchaseOrderRepository : RepositoryBase<PurchaseOrder>
    {
        public PurchaseOrderRepository(IRepository<PurchaseOrder> repository)
            : base(repository)  {  }

        public IEnumerable<PurchaseOrder> GetOrdersByUserID(int userID) 
        {
            return this.Queryable.Where(o => o.UserID == userID).ToArray();
        }
    }
}
