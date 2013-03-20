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
            item.ProductName = product.Name;
            item.PriceOfSingleProduct = product.Price;
            item.Quantity = quantity;

            return item;
        }

        public static PurchaseOrder CreatePurchaseOrder(ShoppingCart shoppingCart) 
        {
            if (shoppingCart.Items == null || shoppingCart.Items.Count < 1) 
                throw new Exception("purchase order cannot be created from empty shopping! Add products to the shopping cart.");

            PurchaseOrder order = new PurchaseOrder();
            order.DateCreated = DateTime.Now;
            order.UserID = shoppingCart.UserID;

            foreach (OrderItem item in shoppingCart.Items) 
            {
                order.Items.Add(item.MakeCopy());
            }

            return order;
        }
    }
}
