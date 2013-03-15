using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Common
{
    public interface IDomainContext
    {
        IRepository<User> Users { get; }
        IRepository<Order> Orders { get; }
        IRepository<Product> Products { get; }
    }
}
