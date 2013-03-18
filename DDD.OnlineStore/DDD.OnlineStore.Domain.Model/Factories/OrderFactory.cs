using DDD.OnlineStore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.OnlineStore.Domain.Factories
{
    public class OrderFactory
    {
        public static OrderItem CreateOrderItem(Product product, int quantity)
        {
            OrderItem item = new OrderItem();
            item.ProductID = product.ID;
            item.PriceOfSingleProduct = product.Price;
            item.Quantity = quantity;

            return item;
        }
    }
}
