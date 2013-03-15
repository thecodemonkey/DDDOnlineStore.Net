using DDD.OnlineStore.Domain.Model;
using DDD.OnlineStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Services
{
    public class PurchaseService : IDisposable
    {
        public OrderRepository _repository;

        public PurchaseService(OrderRepository repository) 
        {
            this._repository = repository;
        }

        public void Purchase(User user, ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
            //Order order = new Order(shoppingCart);

            //this._repository.Add(order);
            //this._repository.Save();
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
